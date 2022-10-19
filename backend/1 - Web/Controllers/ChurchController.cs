using System;
using System.Threading.Tasks;
using Berger.Application.Interfaces;
using Berger.Application.Models.Church;
using Microsoft.AspNetCore.Mvc;

namespace Berger.Web.Controllers
{
    [Route("church")]
    [ApiController]
    public class ChurchController : ControllerBase
    {
        private readonly IChurchService _churchService;

        public ChurchController(IChurchService churchService)
        {
            _churchService = churchService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateChurch(ChurchRequestModel churchRequestModel)
        {
            try
            {
                await _churchService.CreateChurch(churchRequestModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllChurchs()
        {
            try
            {
                var churchs = await _churchService.GetAllChurchs();
                return Ok(churchs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
