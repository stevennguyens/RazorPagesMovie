using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;

        public IndexModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        [BindProperty(SupportsGet = true)] // required for binding on http get requests
        public string? SearchString { get; set; }
        public SelectList? Genre { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? MovieGenre { get; set; }
        public async Task OnGetAsync()
        {
            if (_context.Movie != null)
            {
                // use linq to get list of genres
                IQueryable<string> genreQuery = from m in _context.Movie
                                                orderby m.Genre
                                                select m.Genre;

                var movies = from m in _context.Movie
                             select m;

                if (!string.IsNullOrEmpty(SearchString))
                {
                    movies = movies.Where(s => s.Title.Contains(SearchString));
                }

                if (!string.IsNullOrEmpty(MovieGenre))
                {
                    movies = movies.Where(s => s.Genre == MovieGenre);
                }
                Genre = new SelectList(await genreQuery.Distinct().ToListAsync());
                Movie = await movies.ToListAsync();
            }
        }
    }
}
