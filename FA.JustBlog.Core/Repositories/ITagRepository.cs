namespace FA.JustBlog.Core.Repositories
{
    using FA.JustBlog.Core.Models;

    public interface ITagRepository : IGenericRepository<Tag>
    {
        Tag GetTagByUrlSlug(string urlSlug);
    }
}