using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Http;

namespace ConsoleApp1.Advance_Crouse
{
    public class TestApi
    {
        private static readonly HttpClient client = new HttpClient();
        public static async Task<string> asyncdataFetch(string url, CancellationToken idtoken)
        {
            try
            {
                await Task.Delay(1000, idtoken);
                if (string.IsNullOrEmpty(url))
                    throw new Exception("URl Can't be Empty");

                HttpResponseMessage reponse = await client.GetAsync(url, idtoken);
                reponse.EnsureSuccessStatusCode();
                string data = await reponse.Content.ReadAsStringAsync(idtoken);

                return data;
            }
            catch (TaskCanceledException)
            {
                return "Task was canceled.";
            }
            catch (HttpRequestException ex)
            {
                return $"HTTP Error: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"Unexpected Error: {ex.Message}";
            }
        }
    }
}
