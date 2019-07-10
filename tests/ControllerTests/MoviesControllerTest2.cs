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

namespace MvcMovie.tests.ControllerTests 
{
    public class MoviesControllerTest2 
    {
        MoviesController controller; 
        MvcMovieContext movieContext { get; set; }
        DbContextOptions<MvcMovieContext> options; 
        IServiceCollection services; 

        public IConfiguration Configuration { get; }

        public MoviesControllerTest2() 
        {

            // Create movieContext 
            var optionsBuilder = new DbContextOptionsBuilder<MvcMovieContext>();
            optionsBuilder.UseInMemoryDatabase(databaseName: "temp"); 
                                
            movieContext = new MvcMovieContext(optionsBuilder.Options);

            // use the moviecontext to create moviecontroller 
            controller = new MoviesController(movieContext);             
        }

        [Fact]
        public void aboutNotNullTest() 
        {
            Task<IActionResult> result = controller.Index("some test"); 
            Assert.NotNull(result); 
        }

        [Fact]
        public void movieExistsTest() 
        {
            /*  Movie movie = new Movie(); 
            movie.Id = 9; 
            movie.Price = 10.02; 
            movie.Genre = "Classic"; 
            controller.Create(movie); 
            */ 
            var result = controller.Details(1) ; 
            Assert.Equal(HttpStatusCode.NotFound.ToString(), result.Status.ToString()); 
        }
    }
}