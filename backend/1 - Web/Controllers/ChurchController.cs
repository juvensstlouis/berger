using System;
using System.Threading.Tasks;
using Berger.Application.Interfaces;
using Berger.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Berger.Web.Controllers
{
    [Route("church")]
    [ApiController]
    public class ChurchController : ControllerBase
    {
        private IChurchService _churchService;

        public ChurchController(IChurchService churchService)
        {
            _churchService = churchService;
        }

        [HttpPost]
        [Route("create-church")]
        public async Task<IActionResult> CreateChurch(ChurchRequestModel churchRequestModel)
        {
            try
            {
                await _churchService.CreateChurch(churchRequestModel);
                return Ok("Igreja criada com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
