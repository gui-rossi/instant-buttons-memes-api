using Domains.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace WebAPI.Controllers
{
    [Controller]
    [Route("api/{controller}/")]
    public class ButtonsController : Controller
    {
        private readonly IButtonsService m_buttonService;

        public ButtonsController(IButtonsService buttonService)
        {
            m_buttonService = buttonService;
        }

        [HttpGet("FetchButtons")]
        public async Task<IEnumerable<Button>> GetButtons()
        {
            var rval = await m_buttonService.GetButtonsAsync();

            return rval;
        }
    }
}
