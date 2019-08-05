using Xunit; 
using MvcMovie2.Controllers; 
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models; 
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System; 
using System.IO;
using Xunit.Abstractions;
using MvcMovie.tests.Context; 
using Moq;
using System.Collections.Generic; 

namespace MvcMovie.tests.ControllerTests 
{
    public class MoviesControllerTest4 : MakeConsoleWork
    {
        MoviesController controller; 
        Mock<MvcMovieContext> movieContext { get; set; }
        public MoviesControllerTest4(ITestOutputHelper output) : base(output)
        {
            Console.WriteLine("inside MoviesControllerTest3 constructor");   

            // create movie context with seed data
            GetContextWithData(); 

            // add context to controller 
            controller = new MoviesController(movieContext.Object);  
            
        }

        // Create MovieContext with seed data
        private void GetContextWithData()
        {
            /* var options = new DbContextOptionsBuilder<MvcMovieContext>()
                            .UseInMemoryDatabase(Guid.NewGuid().ToString())
                            .Options; */
            movieContext = new Mock<MvcMovieContext>();
        
            var movie1 = new Movie { Id = 1, Genre = "Classic", Title = "Redemption" };
            var movie2 = new Movie { Id = 2, Title = "Avatar", Genre = "Cartoon"  };

            List<Movie> movieList = new List<Movie>{}; 
            movieList.Add(movie1); 
            movieList.Add(movie2); 
            Mock<IMvcMovieContext> mockDb = new Mock<IMvcMovieContext>();
            
            //movieContext.Setup(m => m.getAllMovies()).Returns(movieList); 
            //movieContext = mockDb; 

            //this.movieContext = (IMvcMovieContext) mockDb; 
            Console.WriteLine("inside movieExistsTest GetContextWithData"); 
        }
        
        [Fact]
        public async void movieExistsTest() 
        {
            Console.WriteLine("inside movieExistsTest"); 
            //Console.WriteLine(movieContext.); 
            var result = await controller.Details(1);
            var okResult = result as ViewResult;
            Assert.NotNull(result); 
            Assert.IsType<Movie>(okResult.ViewName);
            
            //Assert.NotNull(result.ToString()); 
            //Assert.Equal(200, okResult.StatusCode); okResult.v

            //Assert.Equal(HttpStatusCode.NotFound.ToString(), result.Status.ToString()); 
            //Assert.True(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Index");

            //var result1 = await controller.Index("Avatar"); 
            //var okResult = result.Should().BeOfType<CreatedAtActionResult>().Subject;
            //var person = okResult.Value.Should().BeAssignableTo<Person>().Subject;
            //person.Id.Should().Be(51);
            //var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result1.ToString().GetType().GetType());
            
        }
    }
}