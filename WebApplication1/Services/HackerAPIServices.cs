using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class HackerAPIServices : IHackerAPIServices
    {

        public async Task<HackerAPIModel[]> GetTopTwentyResults()
        {
            List<HackerAPIModel> tmpLst = new List<HackerAPIModel>();
            int[] topIds = await this.GetTopListFromAPI();

            foreach(int value in topIds.Take(20))
            {
                using (var client = new HttpClient())
                {
                    var url = new Uri($"https://hacker-news.firebaseio.com/v0/item/{value}.json");

                    try
                    {
                        var response = await client.GetAsync(url);

                        string jsonReturn;
                        using (var content = response.Content)
                        {
                            jsonReturn = await content.ReadAsStringAsync();
                        }

                        tmpLst.Add(JsonConvert.DeserializeObject<HackerAPIModel>(jsonReturn));
                    }
                    catch (Exception ex)
                    { return null; }
                }
            }
            return (from u in tmpLst orderby u.score descending select u).ToArray();
        }


        //This method remains private and separate from "GetTopTwenty" so it can be called by other methods if needed.
        private async Task<int[]> GetTopListFromAPI()
        {
            using (var client = new HttpClient())
            {
                var url = new Uri($"https://hacker-news.firebaseio.com/v0/beststories.json");
                try
                {
                    var response = await client.GetAsync(url);
                    string jsonResult;
                    using (var content = response.Content)
                    {
                        jsonResult = await content.ReadAsStringAsync();
                    }
                    return JsonConvert.DeserializeObject<int[]>(jsonResult);
                }
                catch(Exception ex)
                { return null; }
                
            }
        }

    }
}
