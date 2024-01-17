using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using FreeDev.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FreeDev.Infrastructure.Percistence;

public class FreeDevDbContext : DbContext
{
    public FreeDevDbContext(DbContextOptions<FreeDevDbContext> options) : base(options){}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // modelBuilder.Entity<Project>().HasKey(p => p.Id);
        // modelBuilder.Entity<Project>().HasOne(p => p.Freelancer).WithMany(f => f.ProjectsAsFreelancer).HasForeignKey(p => p.IdFreelancer).OnDelete(DeleteBehavior.Restrict);
        // modelBuilder.Entity<Project>().HasOne(p => p.Client).WithMany(f => f.ProjectsAsClient).HasForeignKey(p => p.IdClient).OnDelete(DeleteBehavior.Restrict);

        // modelBuilder.Entity<ProjectComment>().HasKey(p => p.Id);
        // modelBuilder.Entity<ProjectComment>().HasOne(p => p.Project).WithMany(f => f.Comments).HasForeignKey(p => p.IdProject).OnDelete(DeleteBehavior.Restrict);
        // modelBuilder.Entity<ProjectComment>().HasOne(p => p.User).WithMany(f => f.ProjectComments).HasForeignKey(p => p.IdUser).OnDelete(DeleteBehavior.Restrict);
       
        // modelBuilder.Entity<User>().HasKey(p => p.Id);
        // modelBuilder.Entity<User>().HasMany(u => u.Skills).WithOne().HasForeignKey(u => u.IdSkill).OnDelete(DeleteBehavior.Restrict);

        //modelBuilder.Entity<UserSkill>().HasKey(p => p.Id);
        // modelBuilder.Entity<Skill>().HasKey(p => p.Id);

    }
    public DbSet<Project> Projects { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<ProjectComment> ProjectComments { get; set; }
   

}
