using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheBlogProject.Models
{
    public class Blog
    {
        // ID # of Blog
        public int Id { get; set; }

        // Author Name
        public string BlogUserId { get; set; } 

        // Name of Blog (0 placeholder is meant to hold name of property
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at most {1} characters.", MinimumLength = 2)]
        public string Name { get; set; }

        // Description of Blog
        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} and at most {1} characters.", MinimumLength = 2)]
        public string Description { get; set; }

        // Annotation Creates Dates

        [DataType(DataType.Date)]
        [Display(Name = "Created Date")]
        public DateTime Created { get; set; }

        // Annotation Updates times
        [DataType(DataType.Date)]
        [Display(Name = "Updated Date")]
        public DateTime? Updated { get; set; }

        // Stores the Bytes of File Inside DataBase\
        [Display(Name = "Blog Image")]
        public byte[] ImageData { get; set; }

        // Stores the type of image
        [Display(Name = "Image Type")]
        public string ContentType { get; set; } 

        // Allows User to Select Image
        [NotMapped]
        public IFormFile Image { get; set; }

        // Navigation Property
        [Display(Name = "Author")]
        public virtual BlogUser BlogUser { get; set; }
        public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();


    }
}
