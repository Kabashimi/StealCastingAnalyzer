using System.Threading.Tasks;
using da_service.Entities;
using Microsoft.EntityFrameworkCore;

namespace da_service.Repositories
{
    public class CSTDataRepository : Repository<SCstdata, DataContext>
    {
        public CSTDataRepository(DataContext context) : base(context)
        {
        }
        
        public async Task<SCstdata> GetCSTDataById(int Id)
        {
            return await context.SCstdatas.FirstOrDefaultAsync(o => o.CstdataId == Id);
        }
        
        public async Task<SCstdata> GetCSTDataByHeatId(int Id)
        {
            return await context.SCstdatas.FirstOrDefaultAsync(o => o.HeatId == Id);
        }
    }
}