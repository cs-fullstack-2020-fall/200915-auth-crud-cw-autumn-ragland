using System.ComponentModel.DataAnnotations;

namespace Classwork.Models
{
    // book model used in views and dbset with custom validation and validation messages using model annotations
    public class BookModel
    {
        [Key]
        public int id{get;set;}

        [Required]
        [StringLength(100, ErrorMessage = "A title must be under 100 characters")]
        [Display(Name = "Book Title")]
        public string title{get;set;}

        [Required(ErrorMessage = "An author must be provided, last name only preferred")]
        [Display(Name = "Book Author")]
        public string author{get;set;}

        [Range(100000000, 999999999, ErrorMessage = "The ISBN number must be 9 digits")]
        [Display(Name = "Book ISBN Number")]
        public int isbn {get;set;}

        [Display(Name = "New York Times Best Seller")]
        public bool isBestSeller{get;set;}
    }
}