namespace FA.JustBlog.Core.Repositories
{
    using FA.JustBlog.Core.Models;
    using System.Linq;

    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public Category GetByUrlSlug(string urlSlug)
        {
            var category = MyDbSet.FirstOrDefault(c => c.UrlSlug == urlSlug);
            return category;
        }
    }
}
