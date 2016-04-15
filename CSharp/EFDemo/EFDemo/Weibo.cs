using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo
{
    class Weibo
    {
        public int WeiboId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }

        public List<WeiPost> Posts { get; set; } 

    }
}
