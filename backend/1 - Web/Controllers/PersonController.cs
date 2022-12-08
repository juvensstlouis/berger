using System;
using System.Threading.Tasks;
using Berger.Application.Interfaces;
using Berger.Application.Models.Person;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Berger.Web.Controllers
{
    [Authorize]
    [Route("people")]
    [ApiController]
    public class PersonController : AbstractController
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromBody] PersonRequestModel personRequestModel)
        {
            try
            {
                var userId = GetUserIdFromToken();
                await _personService.CreatePerson(personRequestModel, userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return HandleErrors(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPeople()
        {
            try
            {
                var userId = GetUserIdFromToken();
                var people = await _personService.GetAllPeople(userId);
                return Ok(people);
            }
            catch (Exception ex)
            {
                return HandleErrors(ex);
            }
        }
    }
}
