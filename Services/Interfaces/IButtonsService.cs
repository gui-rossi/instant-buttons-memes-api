using Domains.Entities;
using Domains.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IButtonsService
    {
        Task<List<ButtonVM>> GetButtonsAsync();

        Task<ButtonVM> GetButtonFileAsync(int buttonId);
    }
}
