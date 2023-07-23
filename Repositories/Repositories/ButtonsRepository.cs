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
    public class ButtonsRepository : BaseRepository<Button>, IButtonsRepository
    {
        public ButtonsRepository(DatabaseContext context) : base(context) { }

        public async Task<IEnumerable<Button>> SelectAllAsync()
        {
            return await _dbSet
                .Include(x => x.Category)
                .ToListAsync();
        }

        public IEnumerable<Button> FindMatching(Expression<Func<Button, bool>> predicate)
        {
            var rval = _dbSet.Where(predicate);

            return rval.ToList();
        }
    }
}
