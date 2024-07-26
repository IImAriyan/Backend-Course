using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Backend.Controllers
{
    [Route("api")]
    [ApiController]
    public class CourseController(AppDbContext dbContext) : ControllerBase
    {
    
        public async Task<ActionResult<CourseEntity>> addCourse(CourseEntity formData)
        {
            EntityEntry<CourseEntity> Course = dbContext.Courses.Add(formData);

            await dbContext.SaveChangesAsync();

            return Ok(Course);
        }
        
        // Get Courses
        [HttpGet("Courses/List")]
        public IEnumerable<CourseEntity> GetCourses()
        {
            return dbContext.Courses;
        }
    }
}
