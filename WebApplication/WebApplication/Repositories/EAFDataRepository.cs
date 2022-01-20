using System.Threading.Tasks;
using da_service.Entities;
using Microsoft.EntityFrameworkCore;

namespace da_service.Repositories
{
    public class EAFDataRepository : Repository<SEafdata, DataContext>
    {
        public EAFDataRepository(DataContext context) : base(context)
        {
            
        }

        public async Task<SEafdata> getById(int id)
        {
            return await context.SEafdatas.FirstOrDefaultAsync(o => o.EafdataId == id);
        }

        public async Task<SEafdata> getByHeatId(int heatId)
        {
            return await context.SEafdatas.FirstOrDefaultAsync(o => o.EafdataId == heatId);
        }
    }
}