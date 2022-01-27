using Articles.Domain;
using Articles.Domain.DTOs;
using Articles.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Yzk18Main.MVC.ApiControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleRepository repository;

        public ArticlesController(IArticleRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public Task<PreviewedArticleDTO[]> GetPaged(int pageNum)
        {
            return repository.FindPagedAsync(pageNum, 20);
        }

        [HttpGet]
        public async Task<ActionResult<ArticleDTO?>> GetById(Guid id)
        {
            var article = await repository.FindByIdAsync(id);
            if(article==null)
            {
                return NotFound($"{id} not found");
            }
            return article;
        }
    }
}
