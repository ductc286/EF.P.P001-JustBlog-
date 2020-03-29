namespace FA.JustBlog.Core.Repositories
{
    using FA.JustBlog.Core.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        public IEnumerable<Tag> GetBySize(int size)
        {
            return MyDbSet.Take(size).ToList();
        }

        public Tag GetTagByUrlSlug(string urlSlug)
        {
            var tag = MyDbSet.FirstOrDefault<Tag>(t => t.UrlSlug == urlSlug);
            return tag;
        }
        //public  IQueryable<Tag> FindAll(int size)
        //{
        //    return MyDbSet.Take(size).ToList();
        //}
    }
}
