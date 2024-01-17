using FreeDev.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreeDev.Infrastructure.Persistence.Configuration;

public class ProjectCommentConfiguration: IEntityTypeConfiguration<ProjectComment>
{
    public void Configure(EntityTypeBuilder<ProjectComment> builder)
    {
        builder.HasKey(p => p.Id);
        builder.HasOne(p => p.Project).WithMany(f => f.Comments).HasForeignKey(p => p.IdProject).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(p => p.User).WithMany(f => f.ProjectComments).HasForeignKey(p => p.IdUser).OnDelete(DeleteBehavior.Restrict);
       
    }
}

