using Domains.Entities;
using Domains.VM;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository m_categoryRepo;

        public CategoriesService(ICategoriesRepository categoryRepo)
        {
            m_categoryRepo = categoryRepo;
        }

        public async Task<dynamic> GetCategoriesAsync()
        {
            var categories = await m_categoryRepo.SelectAllAsync();

            return categories;
        }
    }
}
