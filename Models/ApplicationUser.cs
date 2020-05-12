using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie2.Models
{
    [Serializable]
    [Table("AspNetUsers")]
    public class ApplicationUser : IdentityUser<string>
    {
    }
}
