using Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoriesRepository : BaseRepository<Category>, ICategoriesRepository
    {
        public CategoriesRepository(DatabaseContext context) : base(context) { }

        public async Task<IEnumerable<Category>> SelectAllAsync()
        {
            return await _dbSet
                .Include(x => x.Buttons)
                .ToListAsync();
        }
    }
}
