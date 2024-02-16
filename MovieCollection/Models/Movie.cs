using System.ComponentModel.DataAnnotations;

namespace Mission06_Woodman.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieID { get; set; }
        public string MovieCategory { get; set; }
        public string? MovieSubCategory { get; set; }
        public string MovieName { get; set; }
        public int Year { get; set;}
        public string Director { get; set;}
        public string Rating { get; set;}
        public bool Edited { get; set;}
        public string? LentTo { get; set;}
        public string? Notes { get; set;}

    }
}
