using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie2.Models
{
    [Table("AspNetUsers")]
    public class UserProfile
    {
        [Required]
        public string id { get; set; } 
        [Required]
        public string password { get; set; }

    }

}
