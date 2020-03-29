namespace FA.JustBlog.Core.Repositories
{
    using FA.JustBlog.Core.Models;
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Category GetByUrlSlug(string urlSlug);
    }
}
