using Zack.DomainCommons.Models;

namespace Articles.Domain.DTOs
{
    public record PreviewedArticleDTO(Guid Id,DateTime CreationDateTime, string Title);
}
