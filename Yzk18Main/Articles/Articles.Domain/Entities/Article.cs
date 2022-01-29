using Zack.DomainCommons.Models;

namespace Articles.Domain.Entities;
public record Article: AggregateRootEntity
{
    public string HeaderImageUrl { get; private set; }
    public string Title { get; private set; }
    public string Body { get; private set; }
    public ICollection<string> Tags { get; private set; }

    public Article(string title,string body, string headerImageUrl)
    {
        this.Title = title;
        this.Body = body;
        this.HeaderImageUrl = headerImageUrl;
        this.Tags = new string[0];
    }

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

    public Article ChangeHeaderImageUrl(string url)
    {
        this.HeaderImageUrl = url;
        return this;
    }

    public Article ChangeTags(string[] tags)
    {
        this.Tags = tags;
        return this;
    }
}