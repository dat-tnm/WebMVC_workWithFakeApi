using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC_WorkWithFakeAPI.Models.ViewModels
{
    public class PostVM
    {
        public Post Post { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
    }
}
