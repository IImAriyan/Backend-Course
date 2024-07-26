using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;

namespace Backend.Controllers
{
    [Route("api")]
    [ApiController]
    public class StudentsController(AppDbContext dbContext) : ControllerBase
    {
        // Get Students
        [HttpGet("Students/List")]
        public IEnumerable<StudentsEntity> GetStudents()
        {
            return dbContext.Students;
        }


        [HttpPost("Students/Add")]
        public async Task<ActionResult<StudentsEntity>> AddStudent(StudentsEntity dto)
        {
            if (dto.forCourse == 0)
            {
                Response.StatusCode = 400;
                 var errorResponse = new
                {
                    Status = "400",
                    Message = "Ebteda Id Course Student Ra Vared Konid!"
                };
                return BadRequest(errorResponse);
                
                
            }
            EntityEntry<StudentsEntity> student = dbContext.Students.Add(dto);
            await dbContext.SaveChangesAsync();
            return Ok(student);
        }
        

    }   
}
