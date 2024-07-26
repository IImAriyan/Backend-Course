using Microsoft.EntityFrameworkCore;

namespace Backend.Models;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<CourseEntity> Courses { get; set; }

    public DbSet<StudentsEntity> Students { get; set; }

}