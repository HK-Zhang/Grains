using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo
{
    public class OnsiteCourse : Course
    {
        public string Location { get; set; }

        public string Days { get; set; }

        public System.DateTime Time { get; set; }

        public Details Details { get; set; }

        public OnsiteCourse()
        {

            Details = new Details();

        }


    }
}
