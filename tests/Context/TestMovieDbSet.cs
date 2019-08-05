using System;
using System.Linq;
using MvcMovie2.Models; 

namespace MvcMovie2.tests.Context 
{
    class TestProductDbSet : TestDbSet<Movie>
    {
        public override Movie Find(params object[] keyValues)
        {
            return this.SingleOrDefault(movie => movie.Id == (int)keyValues.Single());
        }
    }
}