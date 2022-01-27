using Zack.DomainCommons.Models;

namespace Articles.Domain.Entities;
public record Article: AggregateRootEntity
{
    public MultilingualString Title { get; private set; }
    public MultilingualString Body { get; private set; }
    public ICollection<MultilingualString> Tags { get; private set; }

    public Article ChangeTitle(MultilingualString title)
    {
        this.Title = title;
        return this;
    }

    public Article ChangeBody(MultilingualString body)
    {
        this.Body = body;
        return this;
    }

    public Article ChangeTags(MultilingualString[] tags)
    {
        this.Tags = tags;
        return this;
    }
}