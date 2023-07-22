using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> SelectAllAsync();

        IEnumerable<T> FindMatching(Expression<Func<T, bool>> predicate);
    }
}
