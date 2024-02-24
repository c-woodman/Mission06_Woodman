using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Woodman.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [ForeignKey("Category")]        
        [Required(ErrorMessage = "Please enter a movie category.")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        [Required(ErrorMessage = "Please enter a movie title.")]
        public string Title { get; set; }
        [Range(1880, 2024,ErrorMessage ="You must enter a valid year (betwen 1880 to present).")]
        public int Year { get; set;}
        public string? Director { get; set;}
        public string? Rating { get; set;}
        public bool Edited { get; set;}
        public string? LentTo { get; set;}
        public bool CopiedToPlex { get; set; }
        [MaxLength(25)]
        public string? Notes { get; set;}


    }
}
