using Zack.DomainCommons.Models;

namespace Articles.Domain.Entities;
public record Article: AggregateRootEntity
{
    public string Title { get; private set; }
    public string Body { get; private set; }
    public ICollection<string> Tags { get; private set; }

    public Article ChangeTitle(string title)
    {
        this.Title = title;
        return this;
    }

    public Article ChangeBody(string body)
    {
        this.Body = body;
        return this;
    }

    public Article ChangeTags(string[] tags)
    {
        this.Tags = tags;
        return this;
    }
}