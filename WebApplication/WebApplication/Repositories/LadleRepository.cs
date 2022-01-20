using System.Threading.Tasks;
using da_service.Entities;
using Microsoft.EntityFrameworkCore;

namespace da_service.Repositories
{
    public class LadleRepository : Repository<SGrade, DataContext>
    {
        public LadleRepository(DataContext context) : base(context)
        {
            
        }

        public async Task<SLadle> getById(int id)
        {
            return await context.SLadles.FirstOrDefaultAsync(o => o.LadleId == id);
        }

    }
}