using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Models
{
	public class Movie
	{
        public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		// specifies display name
		[Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseTime { get; set; }
		public string Genre { get; set; } = string.Empty;
		// map price to currency in db
		[Column(TypeName = "decimal(18, 2)")]
		public decimal Price { get; set; }
		// rating property
		public string Rating { get; set; } = string.Empty;
        public Movie()
		{
			
		}
	}
}

