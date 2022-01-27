using Articles.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;
using Zack.DomainCommons.Models;

namespace Articles.Infrastructure.Configs
{
    internal class ArticleConfig : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("T_Articles");
            builder.HasIndex(e=>e.CreationTime);
            builder.Property(e=>e.Title).HasMaxLength(200);
            builder.Property(e => e.Body).HasMaxLength(1024 * 1024);
            builder.Property(e => e.Tags).HasMaxLength(1024).HasConversion(
        v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
        v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions?)null),
        new ValueComparer<ICollection<string>>(
            (c1, c2) => c1.SequenceEqual(c2),
            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
            c => (ICollection<string>)c.ToList())); ;
        }
    }
}
