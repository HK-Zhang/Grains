using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CsPoc
{
    class DataAnnotationDemo
    {
    }

    public class Test
    {
        [Required(ErrorMessage = "")]
        public string Title { get; set; }

        [StringLength(6, ErrorMessage = "xx")]
        public string Name { get; set; }

        public string Email { get; set; }


        [Price(MinPrice = 1.99)]  //自定义验证
        public double Price { get; set; }

    }

    public class PriceAttribute : ValidationAttribute
    {

        public double MinPrice { get; set; }
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            var price = (double)value;
            if (price < MinPrice)
            {
                return false;
            }

            double cents = price - Math.Truncate(price);

            if (cents < 0.99 || cents >= 0.995)
            {
                return false;
            }

            return true;

        }

    }
}
