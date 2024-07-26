using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Backend.Controllers
{
    [Route("api")]
    [ApiController]
    public class CourseController(AppDbContext dbContext) : ControllerBase
    {
        // Add Course
        [HttpPost("Courses/Add")]
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
        
        // Read By One ID
        [HttpPost("Courses/{id}")]
        public async Task<ActionResult<CourseEntity>> getById(int id)
        {
            CourseEntity Course = await dbContext.Courses.FirstOrDefaultAsync(x=>x.Id == id);

            if (Course == null) return NotFound();

            return Ok(Course);
        }
        
        [HttpDelete("Courses/Remove/{id}")]
        public async Task<ActionResult<CourseEntity>> removeCourse(int id)
        {
            CourseEntity Course = await dbContext.Courses.FirstOrDefaultAsync(x=>x.Id == id);

            if (Course == null) return NotFound();

            dbContext.Courses.Remove(Course);
            dbContext.SaveChangesAsync();
            
            return Ok(Course);
        }
        
    }
}
