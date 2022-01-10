using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using JsonSerializer = System.Text.Json.JsonSerializer;
using CsvHelper;

namespace da_service.Utils
{
    public class FormatUtils
    {
        private readonly ILogger<HeatUtils> _logger;
        private readonly IServiceProvider _serviceProvider;

        private readonly HeatUtils _heatUtils; 
        
        public FormatUtils(ILogger<HeatUtils> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            
            _heatUtils = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<HeatUtils>();
        }

        public async Task<String> getHeatTempDiffAsJSON()
        {
            var obj = await _heatUtils.getTempDiffList();
            string jsonString = JsonSerializer.Serialize(obj);
            return jsonString;
        }
        
        public async Task<String> getHeatTempDiffAsJSON(List<int> gradesList)
        {
            var obj = await _heatUtils.getTempDiffList(gradesList);
            string jsonString = JsonSerializer.Serialize(obj);
            return jsonString;
        }
        
        public async Task<String> getTempDiffForGradeAsJSON(int gradeID)
        {
            var obj = await _heatUtils.getTempDiffByGradeId(gradeID);
            string jsonString = JsonSerializer.Serialize(obj);
            return jsonString;
        }
        
        public async Task<String> getTempDiffForHeatAsJSON(int heatId)
        {
            var obj = await _heatUtils.getTempDiff(heatId);
            string jsonString = JsonSerializer.Serialize<HeatTempDiff>(obj);
            return jsonString;
        }

        public async Task<string> getHeatTempDiffForGradeAsCSV(int gradeID)
        {
            var obj = await _heatUtils.getTempDiffByGradeId(gradeID);

            var writer = new StringWriter();
            var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(obj);
            return writer.ToString();
        }
        
        public async Task<string> getHeatTempDiffAsCSV()
        {
            var obj = await _heatUtils.getTempDiffList();
            var writer = new StringWriter();
            var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            foreach (var grade in obj)
            {
                csv.WriteRecords(grade.Heats);
            }
            
            return writer.ToString();
        }
        
        public async Task<string> getHeatTempDiffAsCSV(List<int> gradesList)
        {
            var obj = await _heatUtils.getTempDiffList(gradesList);
            var writer = new StringWriter();
            var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            foreach (var grade in obj)
            {
                csv.WriteRecords(grade.Heats);
            }
            
            return writer.ToString();
        }
    }
}