using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using da_service.Entities;
using Microsoft.EntityFrameworkCore;

namespace da_service.Repositories
{
    public class GradeRepository : Repository<SGrade, DataContext>
    {
        public GradeRepository(DataContext context) : base(context)
        {
        }

        public async Task<SGrade> getById(int id)
        {
            return await context.SGrades.FirstOrDefaultAsync(o => o.GradeId == id);
        }

        public async Task<List<SGrade>> getAllGrades()
        {
            return await context.SGrades.Where(o => o.GradeId != null).ToListAsync();
        }
    }
}