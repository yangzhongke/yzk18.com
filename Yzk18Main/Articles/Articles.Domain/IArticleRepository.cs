using Articles.Domain.DTOs;
using Articles.Domain.Entities;
using Zack.DomainCommons.Models;

namespace Articles.Domain
{
    public interface IArticleRepository
    {
        public Task<ArticleDTO?> FindByIdAsync(Guid articleId);
        public Task<int> FindTotalCountAsync();
        public Task<PreviewedArticleDTO[]> FindPagedAsync(int pageIndex, int pageSize);
    }
}
