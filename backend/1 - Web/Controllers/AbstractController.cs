using System;
using System.Linq;
using Berger.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Berger.Web.Controllers
{
    public class AbstractController : ControllerBase
    {
        protected IActionResult HandleErrors(Exception ex)
        {
            if (ex is BadRequestException)
            {
                return BadRequest(ex.Message);
            }

            if (ex is NotFoundException)
            {
                return NotFound(ex.Message);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, ExceptionMessages.Error500DefaultMessage);
        }

        public static class ExceptionMessages
        {
            public const string Error500DefaultMessage = "Ocorreu um erro inesperado. Entre em contato com o administrador.";
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public Guid GetUserIdFromToken()
        {
            var userIdClaim = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "id");

            if (Guid.TryParse(userIdClaim.Value, out Guid userId))
            {
                return userId;
            }

            return Guid.Empty;
        }
    }
}
