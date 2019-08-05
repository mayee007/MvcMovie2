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
using Xunit.Abstractions;
using System;

namespace MvcMovie.tests.ControllerTests 
{
    public class MoviesControllerTest : MakeConsoleWork
    {
        MoviesController controller; 
        MvcMovieContext movieContext; 
        DbContextOptions<MvcMovieContext> options; 
        IServiceCollection services; 

        public IConfiguration Configuration { get; }

        public MoviesControllerTest(ITestOutputHelper output) : base(output) 
        {
            services.AddDbContext<MvcMovieContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("MovieContext")));

            // Create movieContext 
            var optionsBuilder = new DbContextOptionsBuilder<MvcMovieContext>();
            //optionsBuilder.Options = new DbContextOptionsBuilder<MvcMovieContext>().UseSqlServer("MvnMovie.db").Options;
            movieContext = new MvcMovieContext(optionsBuilder.Options);

            // use the moviecontext to create moviecontroller 
            controller = new MoviesController(movieContext);             
        }

        [Fact]
        public void aboutNotNullTest() 
        {
            Task<IActionResult> result = controller.Index("some test"); 
            Console.WriteLine("inside MoviesControllerTest aboutNotNullTest, result = " + result);   
            Assert.NotNull(result); 
        }

        [Fact]
        public void movieExistsTest() 
        {
            var result = controller.Details(1) ; 
            Assert.Equal(HttpStatusCode.NotFound.ToString(), result.Status.ToString()); 
        }
    }
}