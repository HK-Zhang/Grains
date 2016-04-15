using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo
{
    public class Grade
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
