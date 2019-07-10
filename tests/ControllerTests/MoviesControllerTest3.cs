using Xunit; 
using MvcMovie2.Controllers; 
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models; 
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Moq; 
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System.Net;
using System.Collections.Generic;
using System.Linq; 
using System; 

namespace MvcMovie.tests.ControllerTests 
{
    public class MoviesControllerTest3 
    {
        MoviesController controller; 
        MvcMovieContext movieContext { get; set; }
        DbContextOptions<MvcMovieContext> options; 
        IServiceCollection services; 

        public IConfiguration Configuration { get; }

        public MoviesControllerTest3() 
        {
            movieContext = GetContextWithData(); 
            controller = new MoviesController(movieContext);             
        }

        private MvcMovieContext GetContextWithData()
        {
            var options = new DbContextOptionsBuilder<MvcMovieContext>()
                            .UseInMemoryDatabase(Guid.NewGuid().ToString())
                            .Options;
            var context = new MvcMovieContext(options);
        
            var movie1 = new Movie { Id = 1, Genre = "Classic", Title = "Redemption" };
            var movie2 = new Movie { Id = 2, Title = "Avatar", Genre = "Cartoon"  };
            context.Movie.Add(movie1); 
            context.Movie.Add(movie2); 
            context.SaveChanges();
            return context; 
        }

        [Fact]
        public async void movieExistsTest() 
        {
            var result = controller.Details(9) ; 
            Assert.NotNull(result); 
            //Assert.Equal(HttpStatusCode.NotFound.ToString(), result.Status.ToString()); 
            //Assert.True(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Index");

            var result1 = await controller.Index("Avatar"); 
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result1);
            
        }
    }
}