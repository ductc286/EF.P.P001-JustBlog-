namespace FA.JustBlog.Core.Repositories
{
    using FA.JustBlog.Core.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface IPostRepository : IGenericRepository<Post>
    {
        Post Find(int year, int month, string urlSlug);
        IEnumerable<Post> GetPublisedPosts();
        IEnumerable<Post> GetUnpublisedPosts();
        IEnumerable<Post> GetLatestPost();
        IEnumerable<Post> GetLatestPost(int size);
        IEnumerable<Post> GetPostsByMonth(DateTime monthYear);
        int CountPostsForCategory(string category);
        IQueryable<Post> GetPostsByCategory(string category);
        int CountPostsForTag(string tag);
        IQueryable<Post> GetPostsByTag(string tag);
        IEnumerable<Post> GetMostViewedPost(int size);
        IEnumerable<Post> GetMostViewedPost();
        IEnumerable<Post> GetHighestPosts(int size);
        IEnumerable<Post> GetHighestPosts();
    }
}