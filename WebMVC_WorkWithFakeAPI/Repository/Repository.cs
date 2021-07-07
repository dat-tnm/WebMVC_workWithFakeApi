using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebMVC_WorkWithFakeAPI.Repository.IRepository;

namespace WebMVC_WorkWithFakeAPI.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly string _APIPath;
        protected readonly IHttpClientFactory _clientFactory;

        public Repository(string APIPath, IHttpClientFactory clientFactory)
        {
            _APIPath = APIPath;
            _clientFactory = clientFactory;
        }


        public async Task<bool> CreateAsync(T objectToCreate)
        {
            if (objectToCreate == null)
            {
                return false;
            }

            var request = new HttpRequestMessage(HttpMethod.Post, _APIPath);
            request.Content = new StringContent(
                JsonConvert.SerializeObject(objectToCreate), Encoding.UTF8, "application/json");

            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode != System.Net.HttpStatusCode.Created)
            {
                return false;
            }

            return true;
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, _APIPath + id);
            
            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return false;
            }

            return true;
        }


        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, _APIPath);

            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return new List<T>();
            }

            var jsonString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<IEnumerable<T>>(jsonString);
        }


        public async Task<T> GetAsync(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, _APIPath + id);

            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return null;
            }

            var jsonString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(jsonString);
        }


        public async Task<bool> UpdateAsync(int id, T objectToUpdate)
        {
            if (objectToUpdate == null)
            {
                return false;
            }

            var request = new HttpRequestMessage(HttpMethod.Patch, _APIPath + id);
            request.Content = new StringContent(
                JsonConvert.SerializeObject(objectToUpdate), Encoding.UTF8, "application/json");

            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return false;
            }

            return true;
        }
    }
}
