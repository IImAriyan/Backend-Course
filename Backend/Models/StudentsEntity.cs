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
    
    [MaxLength(200)]
    [Display(Name = "firstName")]
    [Required]
    public string firstName { get; set; }
    
    [MaxLength(200)]
    [Display(Name = "lastName")]
    [Required]
    public string lastName { get; set; }
    
    [MaxLength(200)]
    [Display(Name = "age")]
    [Required]
    public int age { get; set; }
    
    [MaxLength(200)]
    [Display(Name = "forCourse")]
    [Required]
    public int forCourse { get; set; }
}