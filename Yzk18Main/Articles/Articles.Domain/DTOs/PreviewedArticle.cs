using Zack.DomainCommons.Models;

namespace Articles.Domain.DTOs
{
    public record PreviewedArticle(Guid Id,DateTime CreationDateTime, MultilingualString Title);
}
