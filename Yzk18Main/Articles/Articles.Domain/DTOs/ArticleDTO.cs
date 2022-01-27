namespace Articles.Domain.DTOs
{
    public record ArticleDTO(Guid Id, DateTime CreationDateTime, string Title,string Body);
}
