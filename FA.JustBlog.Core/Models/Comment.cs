namespace FA.JustBlog.Core.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        [EmailAddress(ErrorMessage = "Invalid Email address.")]
        public string Email { get; set; }

        public virtual Post Post { get; set; }
        public int PostId { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "Comment header is required.")]
        [Display(Name = "Title")]

        public string CommentHeader { get; set; }

        [Display(Name = "Comment")]
        public string CommentText { get; set; }

        public DateTime CommentTime { get; set; }
    }
}