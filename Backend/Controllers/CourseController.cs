using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api")]
    [ApiController]
    public class CourseController(AppDbContext dbContext) : ControllerBase
    {
    }
}
