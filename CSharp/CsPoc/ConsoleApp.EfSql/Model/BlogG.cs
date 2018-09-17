using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.EfSql.Model
{
    public class BlogG
    {
        private string _validatedUrl;

        public int BlogGId { get; set; }

        public string Url => _validatedUrl;

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
