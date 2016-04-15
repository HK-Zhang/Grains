using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo
{
    public class Blog
    {
        public int PrimaryTrackingKey { get; set; }

        public string Title { get; set; }

        public string BloggerName { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public BlogDetails BlogDetail { get; set; }

        public Byte[] TimeStamp { get; set; }

        public string BlogCode
        {
            get
            {
                return PrimaryTrackingKey + ":" + BloggerName.Substring(0, 1);
            }
        }


    }
}
