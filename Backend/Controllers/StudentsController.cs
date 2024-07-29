using Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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

        
        
        // Add Student
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
            
            var Course = dbContext.Courses.Where(x=>x.Id == dto.forCourse).ToList();
            if (Course.Count == 0)
            {
                Response.StatusCode = 404;
                var errorResponse = new
                {
                    Status = "404",
                    Message = "Chenin Course i Peyda Nashod!"
                };
                return BadRequest(errorResponse);
            }
            
            var messageResponse = new
            {
                Status = 200,
                Message = "Student Successfully Added! Name: "+dto.firstName+"  LastName: "+dto.lastName+" Age: "+dto.age
                
            };
            EntityEntry<StudentsEntity> student = dbContext.Students.Add(dto);
            await dbContext.SaveChangesAsync();
            return Ok(messageResponse);
        }

        
        
        
        
        // Read By One ID
        [HttpGet("Students/{id}")]
        public async Task<ActionResult<StudentsEntity>> readByID(int id)
        {
            StudentsEntity Student =await dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (Student == null) return NotFound();

            return Ok(Student);
        }
        
        
        // Change FirstName ===================================================================================
        [HttpPost("Students/Update/firstName/{id}")]
        public async Task<ActionResult<StudentsEntity>> updateStudentFirstName(int id,string firstname)
        {
            StudentsEntity student = await dbContext.Students.FirstOrDefaultAsync(x=>x.Id == id);

            if (student == null) return NotFound();

            student.firstName = firstname;
            dbContext.SaveChangesAsync();

            Response.StatusCode = 200;
            var MessageResponse = new
            {
                Status = 200,
                Message = "Student FirstName Successfully Updated"
            };
            
            return Ok(MessageResponse);
        }
        // Change FirstName ===================================================================================
        
        
        
        
        // Change LastName ===================================================================================
        [HttpPost("Students/Update/lastName/{id}")]
        public async Task<ActionResult<StudentsEntity>> updateStudentLastName(int id,string lastName)
        {
            StudentsEntity student = await dbContext.Students.FirstOrDefaultAsync(x=>x.Id == id);

            if (student == null) return NotFound();

            student.lastName = lastName;
            dbContext.SaveChangesAsync();

            Response.StatusCode = 200;
            var MessageResponse = new
            {
                Status = 200,
                Message = "Student LastName Successfully Updated"
            };
            
            return Ok(MessageResponse);
        }
        // Change LastName ===================================================================================
        
        
        // Change Age ===================================================================================
        [HttpPost("Students/Update/age/{id}")]
        public async Task<ActionResult<StudentsEntity>> updateStudentAge(int id,int age)
        {
            StudentsEntity student = await dbContext.Students.FirstOrDefaultAsync(x=>x.Id == id);

            if (student == null) return NotFound();

            student.age = age;
            dbContext.SaveChangesAsync();

            Response.StatusCode = 200;
            var MessageResponse = new
            {
                Status = 200,
                Message = "Student age Successfully Updated"
            };
            
            return Ok(MessageResponse);
        }
        // Change Age ===================================================================================
        
        // Change Course ID ===================================================================================
        [HttpPost("Students/Update/Course/{id}")]
        public async Task<ActionResult<StudentsEntity>> updateStudentCourse(int id,int CourseID)
        {
            StudentsEntity student = await dbContext.Students.FirstOrDefaultAsync(x=>x.Id == id);

            if (student == null) return NotFound();

            student.forCourse = CourseID;
            dbContext.SaveChangesAsync();

            Response.StatusCode = 200;
            var MessageResponse = new
            {
                Status = 200,
                Message = "Student Course ID Successfully Updated"
            };
            
            return Ok(MessageResponse);
        }
        // Change Course ID ===================================================================================
        
        // Update Student
        [HttpPost("Students/Update/{id}")]
        public async Task<ActionResult<StudentsEntity>> updateStudent(int id,StudentsEntity data)
        {
            StudentsEntity Student =await dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (Student == null) return NotFound();
            Student.firstName = data.firstName;
            Student.lastName = data.lastName;
            Student.age = data.age;
            Student.forCourse = data.forCourse;

            dbContext.SaveChangesAsync();
            
            var messageResponse = new
            {
                Status = 200,
                Message = "Student Successfully Updated"
                
            };
            return Ok(messageResponse);
        }

        
        
        // Remove Student
        [HttpDelete("Students/Remove/{id}")]
        public async Task<ActionResult<StudentsEntity>> RemoveStudent(int id)
        {
            StudentsEntity Student = await dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (Student == null) return NotFound();
            var messageResponse = new
            {
                Status = 200,
                Message = "Student Successfully Removed"
            };
            
            dbContext.Students.Remove(Student);
            await dbContext.SaveChangesAsync();
            return Ok(messageResponse);
        }
        
        
        
        
    }   
}
