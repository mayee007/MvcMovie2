using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MvcMovie2.tests.ControllerTests
{
    public class MvcMovieContextTest : DbContext
    {
        public MvcMovieContextTest (DbContextOptions<MvcMovieContextTest> options)
            : base(options)
        {
        }

        public DbSet<MvcMovie2.Models.Movie> Movie { get; set; }
    }
}