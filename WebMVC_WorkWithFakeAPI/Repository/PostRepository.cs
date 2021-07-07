using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebMVC_WorkWithFakeAPI.Models;
using WebMVC_WorkWithFakeAPI.Repository.IRepository;

namespace WebMVC_WorkWithFakeAPI.Repository
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(IHttpClientFactory clientFactory) : base("https://jsonplaceholder.typicode.com/posts/", clientFactory)
        {
        }
    }
}
