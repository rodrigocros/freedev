using FreeDev.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FreeDev.Infrastructure.Persistence.Configuration;

public class SkillConfiguration : IEntityTypeConfiguration<Skill>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Skill> builder)
    {
        builder.HasKey(p => p.Id);

    }
}

