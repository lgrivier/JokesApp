using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JokesApp
{
    class JokeProcessor
    {
        public static async Task<JokeModel> LoadJoke()
        {
            string url = "https://api.jokes.one/jod?category=animal";

            using (System.Net.Http.HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    JokeContentModel contents = await response.Content.ReadAsAsync<JokeContentModel>();

                    return contents.contents;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
