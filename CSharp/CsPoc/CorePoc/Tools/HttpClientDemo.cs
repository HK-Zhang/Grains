using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CorePoc.Tools
{
    public class HttpClientDemo
    {
        public static void Execute()
        {
            var httpClient = new HttpClient();
            var response = httpClient.GetAsync("https://localhost:44316/api/Account/GetUserInfo").GetAwaiter().GetResult();
            var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        }
    }
}
