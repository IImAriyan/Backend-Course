using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Swashbuckle.AspNetCore.Annotations;

namespace Backend.Models;

[Table(name:"Courses")]
public class CourseEntity
{
    [Key] 
    [Required]
    [SwaggerIgnore]
    public int Id { get; set; }
    
    [MaxLength(200)]
    [Display(Name = "title")]
    [Required]
    public string title { get; set; }
    
    [MaxLength(200)]
    [Display(Name = "date")]
    [Required]
    public string date { get; set; }
    
    [MaxLength(200)]
    [Display(Name = "Time")]
    [Required]
    public string Time { get; set; }
}