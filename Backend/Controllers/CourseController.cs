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
        // Get Courses
        [HttpGet("Courses/List")]
        public IEnumerable<CourseEntity> GetCourses()
        {
            return dbContext.Courses;
        }

        
        // Add Course
        [HttpPost("Courses/Add")]
        public async Task<ActionResult<CourseEntity>> addCourse(CourseEntity formData)
        {
            EntityEntry<CourseEntity> Course = dbContext.Courses.Add(formData);

            await dbContext.SaveChangesAsync();

            return Ok(Course);
        }
        

        // Read By One ID
        [HttpPost("Courses/{id}")]
        public async Task<ActionResult<CourseEntity>> getById(int id)
        {
            CourseEntity Course = await dbContext.Courses.FirstOrDefaultAsync(x=>x.Id == id);

            if (Course == null) return NotFound();

            return Ok(Course);
        }

        [HttpPost("Courses/Update")]
        public async Task<ActionResult<CourseEntity>> updateCourse(int id,CourseEntity formData)
        {
            CourseEntity Course = await dbContext.Courses.FirstOrDefaultAsync(x=>x.Id == id);

            if (Course == null) return NotFound();
            
            Course.title = formData.title;
            Course.date = formData.date;
            Course.Time = formData.Time;
            dbContext.SaveChangesAsync();

            return Ok(Course);
        }
        
        // Change Title
        [HttpPost("Courses/Update/Title")]
        public async Task<ActionResult<CourseEntity>> updateCourseTitle(int id,string title)
        {
            CourseEntity Course = await dbContext.Courses.FirstOrDefaultAsync(x=>x.Id == id);

            if (Course == null) return NotFound();

            Course.title = title;
            dbContext.SaveChangesAsync();

            return Ok(Course);
        }
        
        // Change Date
        [HttpPost("Courses/Update/Date")]
        public async Task<ActionResult<CourseEntity>> updateCourseDate(int id,string date)
        {
            CourseEntity Course = await dbContext.Courses.FirstOrDefaultAsync(x=>x.Id == id);

            if (Course == null) return NotFound();

            Course.date = date;
            dbContext.SaveChangesAsync();

            return Ok(Course);
        }
        
        // Change Time
        [HttpPost("Courses/Update/Time")]
        public async Task<ActionResult<CourseEntity>> updateCourseTime(int id,string time)
        {
            CourseEntity Course = await dbContext.Courses.FirstOrDefaultAsync(x=>x.Id == id);

            if (Course == null) return NotFound();

            Course.Time = time;
            dbContext.SaveChangesAsync();

            return Ok(Course);
        }
        
        [HttpGet("Courses/Remove/{id}")]
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
