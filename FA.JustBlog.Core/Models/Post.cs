namespace FA.JustBlog.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Configuration;
    using System.Web.Mvc;

    public class Post
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Title name is required.")]
        [StringLength(255)]
        [Display(Name = "Post title")]
        public string Title { get; set; }

        [Column("Short Description")]
        [Required(ErrorMessage = "Short Description is required.")]
        [StringLength(1024)]
        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Content")]
        [AllowHtml]
        public string PostContent { get; set; }

        [Display(Name = "Meta")]
        public string Meta { get; set; }
        
        [Required(ErrorMessage = "Url Slug is required.")]
        [StringLength(255)]
        [Display(Name = "Url")]
        [Index("Ind_UrlSlug", IsUnique = true)]
        //[Remote("IsExist", "Place", ErrorMessage = "URL Slug already exist!")]
        public string UrlSlug { get; set; }

        [Display(Name = "Is Published")]
        public bool Published { get; set; } = false;

        [Column("Posted On")]
        [Display(Name = "Posted On")]
        public DateTime PostedOn { get; set; }

        public DateTime? Modified { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual IList<Tag> Tags { get; set; }

        [Range(0, Int32.MaxValue)]
        public int ViewCount { get; set; } = 0;

        [Range(0, Int32.MaxValue)]
        public int RateCount { get; set; } = 0;

        [Range(0, Int32.MaxValue)]
        public int TotalRate { get; set; } = 0;
        
        [NotMapped]
        public decimal Rate
        {
            get
            {
                if (RateCount == 0)
                {
                    return 0;
                }

                return Math.Round((decimal)TotalRate/ RateCount, 2);
            }
        }

        [NotMapped]
        public string TagValues { get; set; }

        public virtual IList<Comment> Comments { get; set; }
    }
}
