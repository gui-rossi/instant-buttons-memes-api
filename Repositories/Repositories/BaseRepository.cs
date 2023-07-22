using Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity, new()
    {
        protected readonly DatabaseContext _db;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(DatabaseContext context)
        {
            if (context is null) throw new ArgumentNullException("Null Database context");

            _db = context;
            _dbSet = _db.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> SelectAllAsync()
        {
            return await _dbSet
                .AsNoTracking()
                .ToArrayAsync();
        }

        public virtual IEnumerable<T> FindMatching(Expression<Func<T, bool>> predicate)
        {
            var rval =_dbSet.Where(predicate);

            return rval.ToList();
        }
    }
}
