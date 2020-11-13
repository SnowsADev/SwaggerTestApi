using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TestProject_Swagger.Models;
namespace TestProject_Swagger.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        private static List<TeamMember> _Members = new List<TeamMember>()
            {
                new TeamMember(1, "Marc Boerdijk", "s1130154@student.windesheim.nl"),
                new TeamMember(2, "Bram ten Brinke", "s1101299@student.windesheim.nl"),
                new TeamMember(3, "Jeroen ten Hove", "s1094757@student.windesheim.nl"),
                new TeamMember(4, "Amjada Ladhani", "s1114426@student.windesheim.nl"),
                new TeamMember(5, "Tycho Mensing", "s1095019@student.windesheim.nl"),
                new TeamMember(6, "Bart Schrik", "s1105662@student.windesheim.nl"),
                new TeamMember(7, "Alan Snijder", "s1129910@student.windesheim.nl")
            };

        /// <summary>
        /// Gets all members from the team
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/getAll")]
        public IActionResult GetTeamList()
        {
            return Ok(_Members);
        }

        /// <summary>
        /// Gets a member by ID
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/get/{id}")]
        public IActionResult Get([System.Web.Http.FromUri] int id)
        {
            TeamMember result = _Members.FirstOrDefault(x => x.ID == id);

            return Ok(result);
        }

        /// <summary>
        /// Removes member from the team
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("/api/delete/{id}")]
        public IActionResult Delete([System.Web.Http.FromUri] int id)
        {
            TeamMember tl = _Members.FirstOrDefault(x => x.ID == id);

            if (tl == null) return NotFound("No TeamLid with ID exists");

            _Members.Remove(tl);

            return Ok();
        }

        /// <summary>
        /// Adds member to the team
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        [HttpPost("api/add")]
        public IActionResult Add([FromBody] TeamMember member)
        {
            if (!ModelState.IsValid) return BadRequest("Request data not valid.");

            //List already contains an object with given ID
            bool bIDExists = _Members.Any(x => x.ID == member.ID);
            if (bIDExists) return BadRequest("ID is already taken");


            _Members.Add(member);
            return Ok();
        }
    }
}
