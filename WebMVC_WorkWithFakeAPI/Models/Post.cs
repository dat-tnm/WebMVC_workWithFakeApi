using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC_WorkWithFakeAPI.Models
{
    public class Post
    {
        [Required]
        public int UserId { get; set; }
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
    }
}
