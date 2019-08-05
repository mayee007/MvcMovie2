using System;
using System.Data.Entity;
using MvcMovie.Models;
using System.Collections.Generic; 

namespace MvcMovie.tests.Context
{
    public class TestStoreAppContext : IMvcMovieContext 
    {
        public TestStoreAppContext()
        {
            this.Movie = new TestProductDbSet();
        }

        public DbSet<Movie> Movie { get; set; }

        public void MarkAsModified(Movie item) { }
        public void Dispose() { }
        public int SaveChanges()
        {
            return 0;
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