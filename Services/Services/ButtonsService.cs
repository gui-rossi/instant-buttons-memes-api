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

            //var entity = (await m_buttonRepo.SelectAllAsync()).FirstOrDefault();

            //var blob = (await m_blobRepo.GetBlobStreamsAsync()).FirstOrDefault()!;

            //using (var mem = new MemoryStream())
            //{
            //    blob.Position = 0;

            //    blob.CopyTo(mem);

            //    var bytes = mem.ToArray();

            //    var button = new ButtonVM()
            //    {
            //        Name = entity.Name,
            //        File = Convert.ToBase64String(bytes)
            //    };

            //    return button;
            //};
        }

        public async Task<ButtonVM> GetButtonFileAsync(int buttonId)
        {
            var entity = await m_buttonRepo.FindByIdAsync(buttonId);

            if (entity == null)
            {
                throw new Exception($"File {buttonId} does not exist.");
            }



        }
    }
}
