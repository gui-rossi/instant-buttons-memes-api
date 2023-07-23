using Domains.Entities;
using Domains.VM;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace WebAPI.Controllers
{
    [Controller]
    [Route("api/Buttons/")]
    public class ButtonsController : Controller
    {
        private readonly IButtonsService m_buttonService;

        public ButtonsController(IButtonsService buttonService)
        {
            m_buttonService = buttonService;
        }

        [HttpGet("FetchButtons")]
        public async Task<ButtonVM> GetButtons()
        {
            var rval = await m_buttonService.GetButtonsAsync();

            return rval;
        }
    }
}
