using System;
using System.Data.Entity;
using System.Collections.Generic; 

namespace MvcMovie.Models
{
    public interface IMvcMovieContext : IDisposable
    {
        int SaveChanges();
        void MarkAsModified(Movie item);

        Movie Details(int id); 

        List<Movie> getAllMovies(); 
    }
}