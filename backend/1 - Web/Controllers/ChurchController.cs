using System;
using System.Threading.Tasks;
using Berger.Application.Interfaces;
using Berger.Application.Models.Church;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Berger.Web.Controllers
{
    [Authorize]
    [Route("churchs")]
    [ApiController]
    public class ChurchController : AbstractController
    {
        private readonly IChurchService _churchService;

        public ChurchController(IChurchService churchService)
        {
            _churchService = churchService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateChurch([FromBody] ChurchRequestModel churchRequestModel)
        {
            try
            {
                var userId = GetUserIdFromToken();
                await _churchService.CreateChurch(churchRequestModel, userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return HandleErrors(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllChurchs()
        {
            try
            {
                var userId = GetUserIdFromToken();
                var churchs = await _churchService.GetAllChurchs(userId);
                return Ok(churchs);
            }
            catch (Exception ex)
            {
                return HandleErrors(ex);
            }
        }
    }
}
