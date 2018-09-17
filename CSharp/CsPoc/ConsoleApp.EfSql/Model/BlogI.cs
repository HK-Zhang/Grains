using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.EfSql.Model
{
    public class BlogI
    {
        private string _validatedUrl;

        public int BlogIId { get; set; }

        public string GetUrl()
        {
            return _validatedUrl;
        }

        public void SetUrl(string url)
        {
//            using (var client = new HttpClient())
//            {
//                var response = client.GetAsync(url).Result;
//                response.EnsureSuccessStatusCode();
//            }

            _validatedUrl = url;
        }
    }
}
