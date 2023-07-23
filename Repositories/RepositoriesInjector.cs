using Microsoft.Extensions.DependencyInjection;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public static class RepositoriesInjector
    {
        public static void AddRepositories(IServiceCollection services)
        {
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IButtonsRepository, ButtonsRepository>();
        }
    }
}
