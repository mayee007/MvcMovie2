using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie2.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Price { get; set; }

        public string GetPropertyValue(string propertyName)
        {
            try
            {
                return this.GetType().GetProperty(propertyName).GetValue(this, null) as string;
            }
            catch { return null; }
        }
    }
}