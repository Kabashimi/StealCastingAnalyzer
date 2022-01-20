using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using da_service.Entities;
using da_service.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace da_service.Utils
{
    public class HeatUtils
    {
        private readonly HeatRepository _heatRepository;
        private readonly CSTDataRepository _cstDataRepository;
        private readonly CSTTempRepository _cstTempRepository;
        private readonly GradeRepository _gradeRepository;
        private readonly EAFDataRepository _eafDataRepository;

        private readonly ILogger<HeatUtils> _logger;
        private readonly IServiceProvider _serviceProvider;

        public HeatUtils(ILogger<HeatUtils> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;

            _heatRepository = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<HeatRepository>();
            _cstDataRepository = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<CSTDataRepository>();
            _cstTempRepository = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<CSTTempRepository>();
            _gradeRepository = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<GradeRepository>();
            _eafDataRepository = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<EAFDataRepository>();
        }

        public async Task<SHeat> getHeatById(int id)
        {
            var entity = await _heatRepository.GetHeatById(id);
            return entity;
        }

        public async Task<SCstdata> getCSTDataById(int id)
        {
            var entity = await _cstDataRepository.GetCSTDataById(id);
            return entity;
        }
        
        public async Task<HeatTempDiff> getTempDiff(int heatId, string gradeName = "nil")
        {
            var data = await _cstDataRepository.GetCSTDataByHeatId(heatId);
            if(data != null)
            {
                var heat = await _heatRepository.GetHeatById(heatId);
                var temps = await _cstTempRepository.getCSTTempListByCSTDataId(data.CstdataId);
                var eafData = await _eafDataRepository.getByHeatId(heatId);
                int heatsInLadle = eafData == null ? -1 : eafData.HeatsinLadle;
                if(temps != null && temps.Count >1)
                {
                    var tempDiff = temps[0].Value - temps[1].Value;
                    var tmp = temps[1].MeasureTime.Ticks - temps[0].MeasureTime.Ticks;
                    var timeDiff = new TimeSpan(tmp);
                    var heatDiff = new HeatTempDiff(
                        heatId,
                        heat.HeatNumber,
                        heat.GradeId.Value,
                        gradeName,
                        temps[0].MeasureTime,
                        temps[0].Value,
                        tempDiff,
                        timeDiff,
                        timeDiff.TotalSeconds,
                        heat.Weight,
                        data.LadleNumber,
                        heatsInLadle
                    );
                    return heatDiff;
                }
            }
            return null;
        }
        
        public async Task<List<HeatTempDiff>> getTempDiffByGradeId(int gradeId, string gradeName = "nil")
        {
            var heatsList = await _heatRepository.getByGradeId(gradeId);
            List<HeatTempDiff> result = new List<HeatTempDiff>();
            foreach (var heat in heatsList)
            {
                var obj = await getTempDiff(heat.HeatId, gradeName);
                if (obj != null)
                {
                    result.Add(obj);    
                }
            }
            return result;
        }
        
        public async Task<GradeContainer> getTempDiffByGradeIdAsContainer(int gradeId, string gradeName)
        {
            var heatsList = await _heatRepository.getByGradeId(gradeId);
            GradeContainer result = new GradeContainer(gradeId, gradeName);
            foreach (var heat in heatsList)
            {
                var obj = await getTempDiff(heat.HeatId, gradeName);
                if (obj != null)
                {
                    result.Heats.Add(obj);    
                }
                
            }
            return result;
        }
        
        

        public async Task<List<GradeContainer>> getTempDiffList()
        {
            var grades = await _gradeRepository.getAllGrades();
            List<GradeContainer> result = new List<GradeContainer>();
            foreach (var grade in grades)
            {
                var obj = await getTempDiffByGradeIdAsContainer(grade.GradeId, grade.Name);
                if (obj != null)
                {
                    result.Add(obj); 
                }
            }
            return result;
        }

        public async Task<List<GradeContainer>> getTempDiffList(List<int> gradesList)
        {
            List<GradeContainer> result = new List<GradeContainer>();
            foreach (var gradeId in gradesList)
            {
                var gradeObj = await _gradeRepository.getById(gradeId);
                if (gradeObj != null)
                {
                    var obj = await getTempDiffByGradeIdAsContainer(gradeObj.GradeId, gradeObj.Name);
                    if (obj != null)
                    {
                        result.Add(obj);
                    }
                }
            }
            return result;
        }
    }
}