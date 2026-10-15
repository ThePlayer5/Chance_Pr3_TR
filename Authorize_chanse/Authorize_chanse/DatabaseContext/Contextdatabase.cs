using Authorize_chanse.Models;
using Microsoft.EntityFrameworkCore;

namespace Authorize_chanse.DatabaseContext;

public class Contextdatabase : DbContext
{
    public Contextdatabase(DbContextOptions<Contextdatabase> options) : base(options)
    {
        
    }
    
    public DbSet<Roles> Roles { get; set; }
    public DbSet<Logins> Logins { get; set; }
    public DbSet<Users> Users { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<Doctors> Doctors { get; set; }
    public DbSet<Problems>  Problems { get; set; }
    public DbSet<DoctorProblems> DoctorProblems { get; set; }
    public DbSet<MoodTrack>  MoodTrack { get; set; }
    
}