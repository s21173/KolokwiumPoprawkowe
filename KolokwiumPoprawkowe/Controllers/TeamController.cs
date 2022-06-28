using KolokwiumPoprawkowe.Models.DTO;
using KolokwiumPoprawkowe.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KolokwiumPoprawkowe.Controllers
{
    [Route("api/team")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly IDbService dbService;

        public TeamController(IDbService dbService)
        {
            this.dbService = dbService;
        }

        [HttpGet("{idTeam}")]
        public async Task<IActionResult> GetTeam([FromRoute] int idTeam)
        {
            var result = await dbService.GetTeam(idTeam);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddMember(SomeMember someMember)
        {
            bool result = await dbService.AddMemberToTeam(someMember);
            if (!result)
            {
                return BadRequest("Check the data and try again");
            }
            return Ok("Doctor was added");
        }
    }
}
