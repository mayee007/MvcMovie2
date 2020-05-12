using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcMovie2.Models;
//using System.Data.Entity;

namespace MvcMovie2.Models
{
    public class MvcMovieContext : DbContext, IMvcMovieContext
    {
        public MvcMovieContext (DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        public MvcMovieContext()
        {
        }

        /*public MvcMovieContext() //: base("name=MvcMovieContext")
{

} */
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

        public DbSet<MvcMovie2.Models.Movie> Movies { get; set; }

        public DbSet<MvcMovie2.Models.UserProfile> UserProfile { get; set; }
        public DbSet<MvcMovie2.Models.UserProfile> UserProfiles { get; set; }
        public DbSet<MvcMovie2.Models.Role> Roles { get; set; }

    }
}