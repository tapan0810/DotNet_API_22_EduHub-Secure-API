using DotNet_API_22_.Entities.Dtos.SchoolDtos;
using DotNet_API_22_.Service.SchoolService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet_API_22_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController (ISchoolService schoolService): ControllerBase
    {
        [HttpGet("GetAllSchools")]
        public async Task<ActionResult<GetAllSchoolDto>> GetAllSchools()
        {
            var schools = await schoolService.GetAllSchool();
            return Ok(schools);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GetSchoolById?>> GetSchoolById(int id)
        {
            var school = await schoolService.GetSchoolById(id);
            if (school is null)
                return BadRequest("Student not Found");

            return Ok(school);
        }

        [HttpPost("CreateSchool")]
        public async Task<ActionResult<GetSchoolById?>> CreateSchool(CreateSchoolDto school)
        {
            if (school is null)
                return BadRequest();

            var sch = await schoolService.CreateSchool(school);

            return CreatedAtAction(nameof(GetSchoolById), new {id=sch.SchoolId}, sch);

        }

    }
}
