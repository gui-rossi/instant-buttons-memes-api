﻿using Domains.Entities;
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
    public class ButtonsService : IButtonsService
    {
        private readonly IBaseRepository<Button> m_buttonRepo;

        public ButtonsService(IBaseRepository<Button> buttonRepo)
        {
            m_buttonRepo = buttonRepo;
        }

        public async Task<IEnumerable<Button>> GetButtonsAsync()
        {
            var entities = await m_buttonRepo.SelectAllAsync();

            return entities;
        }
    }
}
