using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using da_service.Entities;
using Microsoft.EntityFrameworkCore;

namespace da_service.Repositories
{
    public class CSTTempRepository : Repository<SCsttemp, DataContext>
    {
        public CSTTempRepository(DataContext context) : base(context)
        {
        }
        
        public async Task<SCsttemp> GetCSTTempById(int Id)
        {
            return await context.SCsttemps.FirstOrDefaultAsync(o => o.CsttempId == Id);
        }
        
        public async Task<SCsttemp> GetCSTTempByCSTDataId(int Id)
        {
            return await context.SCsttemps.FirstOrDefaultAsync(o => o.CstdataId == Id);
        }

        public async Task<List<SCsttemp>> getCSTTempListByCSTDataId(int id)
        {
            return await context.SCsttemps.Where(o => o.CstdataId == id).ToListAsync();
        }
    }
}