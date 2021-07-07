using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebMVC_WorkWithFakeAPI.Models;
using WebMVC_WorkWithFakeAPI.Repository.IRepository;

namespace WebMVC_WorkWithFakeAPI.Repository
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(IHttpClientFactory clientFactory) : base("https://jsonplaceholder.typicode.com/comments/", clientFactory)
        {
        }

        public async Task<IEnumerable<Comment>> GetListByPostId(int postId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, _APIPath + $"?postId={postId}");

            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return new List<Comment>();
            }

            var jsonString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<IEnumerable<Comment>>(jsonString);
        }
    }
}
