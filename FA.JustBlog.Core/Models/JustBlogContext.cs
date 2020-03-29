namespace FA.JustBlog.Core.Models
{
    using System.Data.Entity;
    public class JustBlogContext : DbContext
    {
        public JustBlogContext() : base("MyJustBlogDB")
        {
            Database.SetInitializer<JustBlogContext>(new JustBlogInitializer());
        }

        //static BookStoreDbContext()
        //{
        //    Database.SetInitializer<JustBlogContext>(new JustBlogInitializer());
        //}

        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasMany<Tag>(p => p.Tags)
                .WithMany(t => t.Posts)
                .Map(pt =>
                {
                    pt.MapLeftKey("PostId");
                    pt.MapRightKey("TagId");
                    pt.ToTable("PostTagMap");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}