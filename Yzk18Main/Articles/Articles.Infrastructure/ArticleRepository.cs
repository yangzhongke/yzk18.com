using Articles.Domain;
using Articles.Domain.DTOs;
using Articles.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Articles.Infrastructure
{
    internal class ArticleRepository : IArticleRepository
    {
        private ArticleDbContext ctx;

        public ArticleRepository(ArticleDbContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<ArticleDTO?> FindByIdAsync(Guid articleId)
        {
            var a = await ctx.Articles.AsNoTracking().SingleOrDefaultAsync(a=>a.Id==articleId);
            return new ArticleDTO(a.Id, a.CreationTime, a.Title, a.Body);
        }

        public Task<PreviewedArticleDTO[]> FindPagedAsync(int pageIndex, int pageSize)
        {
            return ctx.Articles.AsNoTracking().OrderByDescending(e=>e.CreationTime)
                .Skip(pageIndex *pageSize).Take(pageSize)
                .Select(e=>new PreviewedArticleDTO(e.Id, e.CreationTime,e.Title)).ToArrayAsync();
        }

        public Task<int> FindTotalCountAsync()
        {
            return ctx.Articles.CountAsync();
        }
    }
}
