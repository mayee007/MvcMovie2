using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcMovie2.Models
{
    //[Table("AspNetUsers")]
    public class Role : IdentityRole<string>
    {
        public Role()
        {
        }

        public Role(string name)
        {
            Name = name; 
        }
    }
}
