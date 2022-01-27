using Articles.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Zack.Infrastructure.EFCore;

namespace Articles.Infrastructure
{
    public class ArticleDbContext : BaseDbContext
    {
        public DbSet<Article> Articles { get; private set; }

        public ArticleDbContext(DbContextOptions<ArticleDbContext> options, IMediator? mediator)
            : base(options, mediator)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            modelBuilder.EnableSoftDeletionGlobalFilter();
        }
    }
}
