using Xunit; 
using MvcMovie2.Controllers; 
using Microsoft.AspNetCore.Mvc;
using MvcMovie2.Models; 
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Moq; 
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System.Net;
using Xunit.Abstractions;
using System.IO;
using System;  

namespace MvcMovie2.tests.ControllerTests 
{
    public class MoviesControllerTest2  : MakeConsoleWork
    {
        MoviesController controller; 
        MvcMovieContext movieContext { get; set; }
        DbContextOptions<MvcMovieContext> options; 
        IServiceCollection services; 

        public IConfiguration Configuration { get; }

        public MoviesControllerTest2(ITestOutputHelper output) : base(output)
        {
            Console.WriteLine("inside MoviesControllerTest2 constructor");  
            // Create movieContext 
            var optionsBuilder = new DbContextOptionsBuilder<MvcMovieContext>();
            optionsBuilder.UseInMemoryDatabase(databaseName: "temp"); 
                                
            movieContext = new MvcMovieContext(optionsBuilder.Options);
            Console.WriteLine("inside MoviesControllerTest3 moviecontext " + movieContext);  

            // use the moviecontext to create moviecontroller 
            controller = new MoviesController(movieContext);             
        }

        [Fact]
        public void aboutNotNullTest() 
        {
            Task<IActionResult> result = controller.Index();
            Console.WriteLine("inside MoviesControllerTest3 aboutNotNullTest, result = " + result);   
            Assert.NotNull(result); 
        }

        [Fact]
        public async void movieExistsTest() 
        {
            var result = await controller.Details(4); 
            Console.WriteLine("inside MoviesControllerTest3 movieExistsTest, result = " + result);  
            var resultObj = result as ViewResult; 

            Console.WriteLine("inside MoviesControllerTest3 movieExistsTest, resultObj = " + result);  
            Assert.Equal(HttpStatusCode.NotFound.ToString(), resultObj.StatusCode.ToString()); 
        } 
    }
}