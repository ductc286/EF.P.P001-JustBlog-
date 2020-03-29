namespace FA.JustBlog.Core.Repositories
{
    using FA.JustBlog.Core.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public Post Find(int year, int month, string urlSlug)
        {
            var post =
                MyDbSet.Include("Category").SingleOrDefault<Post>(p => p.Published && p.PostedOn.Year == year && p.PostedOn.Month == month && p.UrlSlug == urlSlug);
            return post;
        }
        public int CountPostsForCategory(string category)
        {

            return MyDbSet.Count(p => p.Category.Name == category);
        }

        public int CountPostsForTag(string tag)
        {
            return MyDbSet.Count(p => p.Tags.Any(t => t.Name == tag));
        }

        public IQueryable<Post> GetPostsByCategory(string category)
        {
            return MyDbSet.Where(p => p.Category.Name == category).OrderByDescending(p => p.PostedOn);
        }

        public IEnumerable<Post> GetPostsByMonth(DateTime monthYear)
        {
            var fromDate = new DateTime(monthYear.Year, monthYear.Month, 1);
            var toDate = fromDate.AddMonths(1).AddDays(-1);
            return MyDbSet.Where(p => p.PostedOn >= fromDate && p.PostedOn <= toDate).ToList();
        }

        public IQueryable<Post> GetPostsByTag(string tag)
        {
            return MyDbSet.Where(p => p.Tags.Any(t => t.UrlSlug == tag)).OrderByDescending(p => p.PostedOn);
        }

        public IEnumerable<Post> GetPublisedPosts()
        {
            return MyDbSet.Where(p => p.Published).OrderByDescending(p => p.PostedOn).ToList();
        }

        public IEnumerable<Post> GetUnpublisedPosts()
        {
            return MyDbSet.Where(p => !p.Published).OrderByDescending(p => p.Modified).ToList();
        }

        public override int Add(Post post)
        {
            MyDbContext.Posts.Add(post);
            post.Tags = new List<Tag>();
            if (!string.IsNullOrEmpty(post.TagValues))
            {
                var tags = post.TagValues.Split(new[] { ";", "," }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string tag in tags)
                {
                    var keyword = tag.Trim();
                    var tagObject = MyDbContext.Tags.Find(keyword);
                    if (tagObject == null)
                    {
                        var newTag = new Tag()
                        {
                            Name = keyword,
                            UrlSlug = keyword,
                            Count = 1,
                            Description = keyword
                        };
                        newTag = MyDbContext.Tags.Add(newTag);
                        post.Tags.Add(newTag);
                    }
                    else
                    {
                        tagObject.Count += 1;
                        MyDbContext.Entry(tagObject).State = System.Data.Entity.EntityState.Modified;
                        post.Tags.Add(tagObject);
                    }
                }
            }

            return MyDbContext.SaveChanges();
        }
        public IEnumerable<Post> GetLatestPost(int size)
        {
            return MyDbSet.Where(p => p.Published).OrderByDescending(p => p.PostedOn).Take(size).ToList();
        }

        public IEnumerable<Post> GetLatestPost()
        {
            return MyDbSet.OrderByDescending(p => p.PostedOn).ToList();
        }
        public IEnumerable<Post> GetMostViewedPost(int size)
        {
            return MyDbSet.Where(p => p.Published).OrderByDescending(p => p.ViewCount).Take(size).ToList();
        }
        public IEnumerable<Post> GetMostViewedPost()
        {
            return MyDbSet.OrderByDescending(p => p.ViewCount).ToList();
        }

        public IEnumerable<Post> GetHighestPosts()
        {
            return MyDbSet.OrderByDescending(p => p.Rate).ToList();
        }
        public IEnumerable<Post> GetHighestPosts(int size)
        {
            return MyDbSet.Where(p => p.Published).OrderByDescending(p => p.Rate).Take(size).ToList();
        }
    }
}
