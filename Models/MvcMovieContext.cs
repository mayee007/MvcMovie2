using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MvcMovie.Models
{
    public class MvcMovieContext : DbContext, IMvcMovieContext
    {
        public MvcMovieContext (DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; }
        public void MarkAsModified(Movie item)
        {
            Entry(item).State = EntityState.Modified;
        }

        public Movie Details(int id)
        {
            return new Movie(); 
        } 

        public List<Movie> getAllMovies()
        {
            return new List<Movie>{ new Movie(), new Movie()}; 
        }
    }
}