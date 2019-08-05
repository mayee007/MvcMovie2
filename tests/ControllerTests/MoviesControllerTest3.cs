using Xunit; 
using MvcMovie2.Controllers; 
using Microsoft.AspNetCore.Mvc;
using MvcMovie2.Models; 
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System; 
using System.IO;
using Xunit.Abstractions;

namespace MvcMovie2.tests.ControllerTests 
{
    public class MoviesControllerTest3 : MakeConsoleWork
    {
        MoviesController controller; 
        MvcMovieContext movieContext { get; set; }
        public MoviesControllerTest3(ITestOutputHelper output) : base(output)
        {
            Console.WriteLine("inside MoviesControllerTest3 constructor");   

            // create movie context with seed data
            GetContextWithData(); 

            // add context to controller 
            controller = new MoviesController(movieContext);  
        }

        // Create MovieContext with seed data
        private void GetContextWithData()
        {
            var options = new DbContextOptionsBuilder<MvcMovieContext>()
                            .UseInMemoryDatabase(Guid.NewGuid().ToString())
                            .Options;
            movieContext = new MvcMovieContext(options);
        
            var movie1 = new Movie { Id = 1, Genre = "Classic", Title = "Redemption" };
            var movie2 = new Movie { Id = 2, Title = "Avatar", Genre = "Cartoon"  };
            movieContext.Movie.Add(movie1); 
            movieContext.Movie.Add(movie2); 
            movieContext.SaveChanges(); 

            Console.WriteLine("inside movieExistsTest GetContextWithData"); 
        }
        
        [Fact]
        public async void movieExistsTest() 
        {
            Console.WriteLine("inside movieExistsTest"); 
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