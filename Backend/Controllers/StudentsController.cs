using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        
    }
}
