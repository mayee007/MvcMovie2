using System;
using System.Linq;
using MvcMovie.Models; 

namespace MvcMovie.tests.Context 
{
    class TestProductDbSet : TestDbSet<Movie>
    {
        public override Movie Find(params object[] keyValues)
        {
            return this.SingleOrDefault(movie => movie.Id == (int)keyValues.Single());
        }
    }
}