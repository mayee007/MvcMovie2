using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MvcMovie2.Models;

namespace MvcMovie2.Controllers
{
    
    public class BaseController : Controller
    {
        //protected MvcMovieContext dbContext;
        protected string appName = "Movie";

        public BaseController() { }

        //public BaseController(MvcMovieContext context)
        //{
         //   dbContext = context; 
        //}

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
    }
}