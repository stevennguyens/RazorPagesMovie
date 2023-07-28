using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Models
{
	public class Movie
	{
        public int Id { get; set; }

		[Required]
		[StringLength(60, MinimumLength = 3)]
		public string Title { get; set; } = string.Empty;

		// specifies display name
		[Display(Name = "Release Date")]

        [DataType(DataType.Date)]
        public DateTime ReleaseTime { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(30)]
        public string Genre { get; set; } = string.Empty;

		// map price to currency in db
		[Column(TypeName = "decimal(18, 2)")]
        [Range(1, 00)]
		[DataType(DataType.Currency)]
        public decimal Price { get; set; }

		[Required]
		[RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
		[StringLength(5)]
		// rating property
		public string Rating { get; set; } = string.Empty;
        public Movie()
		{
			
		}
	}
}

