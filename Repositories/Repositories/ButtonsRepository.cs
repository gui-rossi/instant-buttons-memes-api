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

        public async Task<List<Button>> SelectAllAsync(bool includeCategory = false)
        {
            if (includeCategory)
            {
                return await _dbSet
                    .Include(x => includeCategory)
                    .ToListAsync();
            }

            return await _dbSet
                .ToListAsync();
        }

        public IEnumerable<Button> FindMatching(Expression<Func<Button, bool>> predicate)
        {
            var rval = _dbSet.Where(predicate);

            return rval.ToList();
        }

        public async Task<Button> FindByIdAsync(int buttonId)
        {
            return await _dbSet.FindAsync(buttonId);
        }

        public void UpdateButtonAsync(Button button)
        {
            _dbSet.Update(button);
            ApplyChanges();
        }

        public void ApplyChanges()
        {
            _db.SaveChanges();
        }
    }
}
