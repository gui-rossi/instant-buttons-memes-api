using AutoMapper;
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
    public class ButtonsService : IButtonsService
    {
        private readonly IButtonsRepository m_buttonRepo;
        
        private readonly IBlobStorageService m_blobRepo;

        private readonly IMapper m_mapper;

        public ButtonsService(IButtonsRepository buttonRepo, IBlobStorageService blobRepo, IMapper mapper)
        {
            m_buttonRepo = buttonRepo;
            m_blobRepo = blobRepo;
            m_mapper = mapper;
         }

        public async Task<List<ButtonVM>> GetButtonsAsync()
        {
            var entities = await m_buttonRepo.SelectAllAsync();

            var buttons = m_mapper.Map<List<ButtonVM>>(entities);

            return buttons;
        }

        public async Task<ButtonVM> GetButtonFileAsync(int buttonId)
        {
            var entity = await m_buttonRepo.FindByIdAsync(buttonId);

            if (entity == null)
            {
                throw new Exception($"Entity {buttonId} does not exist in the database.");
            }

            var file = await m_blobRepo.GetBlobStreamAsync(entity.Name);

            if (file == null)
            {
                throw new Exception($"File {entity.Name} does not exist in the container.");
            }

            var button = new ButtonVM()
            {
                Id = buttonId,
                Name = entity.Name,
                File = Convert.ToBase64String(file.ToArray()),
            };

            return button;
        }
    }
}
