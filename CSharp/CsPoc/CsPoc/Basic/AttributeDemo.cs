using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CsPoc
{
    class AttributeDemo
    {

        public static void Execute() {
            //var attrs = Attribute.GetCustomAttributes(typeof(CountryAttribute));
            //AttributeUsageAttribute attr = attrs.OfType<AttributeUsageAttribute>().First();

            var attr =  (AttributeUsageAttribute)Attribute.GetCustomAttribute(typeof(CountryAttribute), typeof(AttributeUsageAttribute));
            Console.WriteLine(attr.AllowMultiple);
        }

        public static void RunDemo()
        {
            Hoopster hr = new Hoopster();
            hr.Play();


            //get attribut of a class
            if (Attribute.IsDefined(hr.GetType(), typeof(CountryAttribute)))
            {
                Attribute[] attributs = Attribute.GetCustomAttributes(hr.GetType());

                foreach (Attribute att in attributs)
                {
                    CountryAttribute ca = att as CountryAttribute;

                    if (ca != null)
                    {
                        Console.WriteLine(string.Format("运动类型：{0}  运动员人数：{1}", ca.Name, ca.PlayerCount));
                    }
                }
            }
        }
    }

    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = true)]
    sealed class CountryAttribute : Attribute
    {

        public CountryAttribute(string name)
        {
            this.Name = name;
        }

        public CountryAttribute()
        { 
        }

        public int PlayerCount { get; set; }
        public string Name { get; set; }

    }

    [Country("china")]
    public class SportsMan
    {
        [Country("ball",PlayerCount=5)]
        public virtual void Play()
        { 
        }

        public string Name { get; set; }
    }

    public class Hoopster:SportsMan
    {
        public override void Play()
        {
            MemberInfo[] members = this.GetType().GetMembers();

            foreach (MemberInfo item in members)
            { 
                if(Attribute.IsDefined(item,typeof(CountryAttribute)))
                {
                    Attribute[] attributs = Attribute.GetCustomAttributes(item);

                    foreach (Attribute att in attributs)
                    {
                        CountryAttribute ca = att as CountryAttribute;

                        if (ca != null)
                        {
                            Console.WriteLine(string.Format("运动类型：{0}  运动员人数：{1}", ca.Name, ca.PlayerCount));
                        }
                    }
                }
            }
        }
    }
}
