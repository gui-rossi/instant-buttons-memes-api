﻿using Domains.Entities;
using Domains.VM;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace WebAPI.Controllers
{
    [Controller]
    [Route("api/Button/")]
    public class ButtonsController : Controller
    {
        private readonly IButtonsService m_buttonService;

        public ButtonsController(IButtonsService buttonService)
        {
            m_buttonService = buttonService;
        }

        [HttpGet("FetchButtons")]
        public async Task<List<ButtonVM>> GetButtons()
        {
            var rval = await m_buttonService.GetButtonsAsync();

            return rval;
        }

        [HttpGet("FetchButtonFile/{buttonId:int}")]
        public async Task<ButtonVM> GetButtonFile(int buttonId)
        {
            var rval = await m_buttonService.GetButtonFileAsync(buttonId);

            return rval;
        }
    }
}
