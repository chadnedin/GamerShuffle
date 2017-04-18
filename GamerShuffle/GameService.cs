using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;
using System.Net;
using System.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace GamerShuffle
{
   public class GameService
    {

        private const string GET_GAMES = "https://igdbcom-internet-game-database-v1.p.mashape.com/games/?fields=id,name,genres,summary,release_dates.platform&filter[release_dates.platform][eq]=3&order=popularity";

        public async Task<List<Games>> GetGameListAsync()
        {
            HttpClient httpClient = new HttpClient();

            // Adding Accept-Type as application/json header
            httpClient.DefaultRequestHeaders.Add("X-Mashape-Key", "ieOCyvYs1KmshJWmy0jXYdcLiBsHp1DCKIKjsndNH1PnShBC0a");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await httpClient.GetAsync(GET_GAMES);
            if (response != null || response.IsSuccessStatusCode)
            {

                // await! control returns to the caller and the task continues 
                string content = await response.Content.ReadAsStringAsync();

                // Printing response body in console 
                Console.Out.WriteLine("Response Body: \r\n {0}", content);

                // Initialize the poi list 
                var gameListData = new List<Games>();

                // Load a JObject from response string
                JObject jsonResponse = JObject.Parse(content);
                IList<JToken> results = jsonResponse["games"].ToList();
                foreach (JToken token in results)
                {
                    Games game = token.ToObject<Games>();
                    gameListData.Add(game);
                }

                return gameListData;
            }
            else
            {
                Console.Out.WriteLine("Failed to fetch data. Try again later!");
                return null;
            }

        }


        //public async Task<JsonValue> FetchInfoAsync(string url)
        //{
        //     var newApi  = (HttpWebRequest)WebRequest.Create(new Uri("https://igdbcom-internet-game-database-v1.p.mashape.com/games/?fields=id,name,genres,summary,release_dates.platform&filter[release_dates.platform][eq]=3&order=popularity"));
        //   newApi.Headers.Add("X-Mashape-Key", "ieOCyvYs1KmshJWmy0jXYdcLiBsHp1DCKIKjsndNH1PnShBC0a");
        //    newApi.Headers.Add("Accept", "application/json");
        //    newApi.Method = "GET";
        //    Console.Out.WriteLine(newApi);
        //    using (WebResponse response = await newApi.GetResponseAsync())
        //    {
        //        using (Stream stream = response.GetResponseStream())
        //        {
        //            JsonValue jsonDoc = await Task.Run(() => JsonValue.Load(stream));
        //            Console.Out.WriteLine("Response: {0}", jsonDoc.ToString());

        //            return jsonDoc;

        //        }
        //    }
        //}

        //private async void HttpClientCall()
        //{
        //    // Create a client
        //    HttpClient httpClient = new HttpClient();

        //    // Add a new Request Message
        //    HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Put, "http://yoursitehere/");

        //    // Add our custom headers
        //    requestMessage.Headers.Add("User-Agent", "User-Agent-Here");
        //    requestMessage.Headers.Add("Content-Type", "MIME-Type-Here");

        //    // Send the request to the server
        //    HttpResponseMessage response = await httpClient.SendAsync(requestMessage);

        //    // Just as an example I'm turning the response into a string here
        //    string responseAsString = await response.Content.ReadAsStringAsync();
        //}

    }
}