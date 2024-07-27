using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        // Get Courses
        
        
        
        // Add Course
        [HttpPost("Courses/Add")]
        public async Task<ActionResult<CourseEntity>> addCourse(CourseEntity formData)
        {
            EntityEntry<CourseEntity> Course = dbContext.Courses.Add(formData);

            await dbContext.SaveChangesAsync();

            Response.StatusCode = 200;
            var MessageResponse = new
            {
                Status = 200,
                Message = "Course Successfully Added"
            };
            
            return Ok(MessageResponse);
        }
        // Add Course
        
        
        
        // Read By One ID
        [HttpPost("Courses/{id}")]
        public async Task<ActionResult<CourseEntity>> getById(int id)
        {
            CourseEntity Course = await dbContext.Courses.FirstOrDefaultAsync(x=>x.Id == id);

            if (Course == null) return NotFound();

            return Ok(Course);
        }
        // Read By One ID
        
        
        
        // Update Course
        [HttpPost("Courses/Update")]
        public async Task<ActionResult<CourseEntity>> updateCourse(int id,CourseEntity formData)
        {
            CourseEntity Course = await dbContext.Courses.FirstOrDefaultAsync(x=>x.Id == id);

            if (Course == null) return NotFound();
            
            Course.title = formData.title;
            Course.date = formData.date;
            Course.Time = formData.Time;
            dbContext.SaveChangesAsync();

            Response.StatusCode = 200;
            var MessageResponse = new
            {
                Status = 200,
                Message = "Course Successfully Updated"
            };
            
            return Ok(MessageResponse);
        }
        // Update Course
        
        
        // Change Title ===================================================================================
        [HttpPost("Courses/Update/Title/{id}")]
        public async Task<ActionResult<CourseEntity>> updateCourseTitle(int id,string title)
        {
            CourseEntity Course = await dbContext.Courses.FirstOrDefaultAsync(x=>x.Id == id);

            if (Course == null) return NotFound();

            Course.title = title;
            dbContext.SaveChangesAsync();

            Response.StatusCode = 200;
            var MessageResponse = new
            {
                Status = 200,
                Message = "Course Title Successfully Updated"
            };
            
            return Ok(MessageResponse);
        }
        // Change Title ===================================================================================
        
        
        //=================== Change Date ================================================================
        [HttpPost("Courses/Update/Date/{id}")]
        public async Task<ActionResult<CourseEntity>> updateCourseDate(int id,string date)
        {
            CourseEntity Course = await dbContext.Courses.FirstOrDefaultAsync(x=>x.Id == id);

            if (Course == null) return NotFound();

            Course.date = date;
            dbContext.SaveChangesAsync();

            Response.StatusCode = 200;
            var MessageResponse = new
            {
                Status = 200,
                Message = "Course Date Successfully Updated"
            };
            
            return Ok(MessageResponse);
        }
        //=================== Change Date ================================================================
        
        
        // Change Time
        [HttpPost("Courses/Update/Time/{id}")]
        public async Task<ActionResult<CourseEntity>> updateCourseTime(int id,string time)
        {
            CourseEntity Course = await dbContext.Courses.FirstOrDefaultAsync(x=>x.Id == id);

            if (Course == null) return NotFound();

            Course.Time = time;
            dbContext.SaveChangesAsync();

            Response.StatusCode = 200;
            var MessageResponse = new
            {
                Status = 200,
                Message = "Course Time Successfully Updated"
            };
            
            return Ok(MessageResponse);
        }
        // Change Time
        
        
        
        // Remove Course
        [HttpGet("Courses/Remove/{id}")]
        public async Task<ActionResult<CourseEntity>> removeCourse(int id)
        {
            CourseEntity Course = await dbContext.Courses.FirstOrDefaultAsync(x=>x.Id == id);

            if (Course == null) return NotFound();

            dbContext.Courses.Remove(Course);
            dbContext.SaveChangesAsync();
            
            var MessageResponse = new
            {
                Status = 200,
                Message = "Course Successfully Removed"
            };
            
            return Ok(MessageResponse);
        }
        // Remove Course
        
        
        
        // Get Students by Course ID
        [HttpGet("Courses/Students/{id}")]
        public async Task<ActionResult<StudentsEntity>> findCourseStudents(int id)
        {
            var Student = dbContext.Students.Where(x => x.forCourse == id).ToList();
            
            if (Student.Count == 0) return NotFound();
            
            return Ok(Student);
        }
        // Get Students by Course ID
        
        
    }
}
