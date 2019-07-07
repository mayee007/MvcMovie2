using Xunit; 
using System; 
using MvcMovie.Models; 
namespace MvcMovie.tests.ModelTests 
{
    public class MovieTest
    {
        Movie movie; 

        public MovieTest()
        {
            movie = new Movie(); 
            movie.Id = 10; 
            movie.Genre = "Classic"; 
            movie.Price = 15.60M; 
            movie.Title = "Deep Blue Sea"; 
            movie.ReleaseDate = DateTime.Parse("1989-2-12");
        }

        [Fact]
        public void Id() 
        {
            Assert.Equal(10, movie.Id); 
            Assert.Equal("Classic", movie.Genre);
            Assert.Equal("Deep Blue Sea", movie.Title);
            Assert.Equal(DateTime.Parse("1989-2-12"), movie.ReleaseDate);
        }
    }
}