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
            var messageResponse = new
            {
                Status = 200,
                Message = "Student Successfully Added! Name: "+dto.firstName+"  LastName: "+dto.lastName+" Age: "+dto.age
                
            };
            return Ok(messageResponse);
        }


        [HttpGet("Students/{id}")]
        public async Task<ActionResult<StudentsEntity>> readByID(int id)
        {
            StudentsEntity Student =await dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (Student == null) return NotFound();

            return Ok(Student);
        }
        

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


        [HttpDelete("Students/Remove/{id}")]
        public async Task<ActionResult<StudentsEntity>> RemoveStudent(int id)
        {
            StudentsEntity Student = await dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (Student == null) return NotFound();

            dbContext.Students.Remove(Student);
            dbContext.SaveChangesAsync();

            var messageResponse = new
            {
                Status = 200,
                Message = "Student Successfully Removed"
                
            };
            return Ok(messageResponse);
        }
        
    }   
}
