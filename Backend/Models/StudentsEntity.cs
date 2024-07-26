using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Swashbuckle.AspNetCore.Annotations;

namespace Backend.Models;

[Table(name:"Students")]
public class StudentsEntity
{
    [Key] 
    [Required]
    [SwaggerIgnore]
    public int Id { get; set; }
    

    [Required]
    public string firstName { get; set; }
    

    [Required]
    public string lastName { get; set; }
    

    [Required]
    public int age { get; set; }
    

    [Required]
    public int forCourse { get; set; }
}