using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace API_internship
{
    public static class ApiHelper<T>
    {
        public static async Task<List<T>> GetAll(string url)
        {
            var list = new List<T>();

            using (var client = new HttpClient())
            {
                var endpoint = new Uri(url);
                var response = client.GetAsync(endpoint).Result;
                var json = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<T>>(json);

                if (!response.IsSuccessStatusCode)
                    throw new FailedGetException();
            }

            return list;
        }

        public static async Task<T> GetOne(string url)
        {
            using var client = new HttpClient();
            var endpoint = new Uri(url);
            var response = client.GetAsync(endpoint).Result;
            var json = response.Content.ReadAsStringAsync().Result;
            var item = JsonConvert.DeserializeObject<T>(json);

            if (!response.IsSuccessStatusCode)
                throw new FailedGetException();

            return item;
        }

        public static async Task<T> PostOne(T item, string url)
        {
            using var client = new HttpClient();
            var endpoint = new Uri(url);
            var stringPayload = JsonConvert.SerializeObject(item);
            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, httpContent);

            var json = response.Content.ReadAsStringAsync().Result;

            if(!response.IsSuccessStatusCode)
                throw new FailedPostException();

            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
