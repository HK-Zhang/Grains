using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo
{
    class WeiPost
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        //public int WeiboId { get; set; }
        public Weibo Weibo { get; set; }

        public Byte[] TimeStamp { get; set; }

    }
}
