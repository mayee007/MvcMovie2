using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvcMovie2.Models
{
    public interface IMvcMovieContext : IDisposable
    {
        int SaveChanges();
        void MarkAsModified(Movie item);

        Movie Details(int id); 

        List<Movie> getAllMovies();

        DbSet<Movie> Movies { get; }
        DbSet<Movie> Movie { get; }

        //void Add(Movie movie);
    }
}