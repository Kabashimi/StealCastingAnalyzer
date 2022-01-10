using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using da_service.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace da_service.Repositories
{
    public class HeatRepository : Repository<SHeat, DataContext>
    {
        public HeatRepository(DataContext context) : base(context)
        {
        }

        public async Task<SHeat> GetHeatById(int Id)
        {
            return await context.SHeats.FirstOrDefaultAsync(o => o.HeatId == Id);
        }

        public async Task<List<SHeat>> getByGradeId(int gradeId)
        {
            return await context.SHeats.Where(o => o.GradeId == gradeId).ToListAsync();
        }
    }
}