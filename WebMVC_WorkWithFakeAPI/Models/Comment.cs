using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC_WorkWithFakeAPI.Models
{
    public class Comment
    {
        [Required]
        public int PostId { get; set; }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Body { get; set; }
    }
}
