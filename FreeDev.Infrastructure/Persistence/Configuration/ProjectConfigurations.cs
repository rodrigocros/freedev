using FreeDev.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreeDev.Infrastructure.Persistence.Configuration;

public class ProjectConfigurations : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasKey(p => p.Id);
        builder.HasOne(p => p.Freelancer).WithMany(f => f.ProjectsAsFreelancer).HasForeignKey(p => p.IdFreelancer).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(p => p.Client).WithMany(f => f.ProjectsAsClient).HasForeignKey(p => p.IdClient).OnDelete(DeleteBehavior.Restrict);
    }
}
