using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcMovie2.Models;

namespace MvcMovie2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIMoviesController : ControllerBase
    {
        private IMvcMovieContext _context;
        public APIMoviesController(MvcMovieContext context)
        {
            _context = context; 
        }

        // GET: api/APIMovies
        [HttpGet]
        public List<Movie> Get()
        {
            return _context.Movies.ToList(); 
        }

        // GET: api/APIMovies/5
        [HttpGet("{id}", Name = "Get")]
        public Movie Get(int id)
        {
            Console.WriteLine("inside api/APIMovies/?, and ID is " + id); 
            return _context.Details(id);
        }

        // POST: api/APIMovies
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/APIMovies/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
