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

        public Task<Article?> FindByIdAsync(Guid articleId)
        {
            return ctx.Articles.SingleOrDefaultAsync(a=>a.Id==articleId);
        }

        public Task<PreviewedArticle[]> FindPagedAsync(int pageIndex, int pageSize)
        {
            return ctx.Articles.OrderByDescending(e=>e.CreationTime)
                .Skip(pageIndex *pageSize).Take(pageSize)
                .Select(e=>new PreviewedArticle(e.Id, e.CreationTime,e.Title)).ToArrayAsync();
        }

        public Task<int> FindTotalCountAsync()
        {
            return ctx.Articles.CountAsync();
        }
    }
}
