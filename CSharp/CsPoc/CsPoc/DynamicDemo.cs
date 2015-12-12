using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CsPoc
{
    class DynamicDemo
    {
        public void VsObject()
        {
            dynamic dyn = 1;
            object obj = 1;

            System.Console.WriteLine(dyn.GetType());
            System.Console.WriteLine(obj.GetType());

            dyn = dyn + 1;
            //obj = obj + 1; error
            System.Console.WriteLine(dyn);
        }

        public void PropertyDemo() 
        {
            dynamic dyn = new Product();

            //dyn.name = "n1"; error

            dyn.ID = 1;
            dyn.ID = dyn.ID + 1;

            dyn.ShowProduct();
        }

        public void ReflectionDemo() 
        {
            Type productType = typeof(Product);
            Product p = new Product();
            FieldInfo fi = productType.GetField("name",BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            fi.SetValue(p, "set by reflection");

            p.ID = 2;
            p.ShowProduct();


        }


        public void ExpandoObjectDemo() 
        {
            dynamic dyn = new ExpandoObject();
            dyn.number = 1;
            dyn.Increment = new Action(() => { dyn.number++; });

            Console.WriteLine(dyn.number);
            dyn.Increment();
            Console.WriteLine(dyn.number);

            foreach (var propery in (IDictionary<string, object>)dyn) 
            {
                Console.WriteLine(propery.Key+":"+propery.Value);
            }

            ((INotifyPropertyChanged)dyn).PropertyChanged += DynamicDemo_PropertyChanged;
            dyn.name = "changed";
            dyn.name = "another";

        }

        void DynamicDemo_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Console.WriteLine("property: {0} is changed", e.PropertyName);
        }

        public void DynamicProductDemo() 
        {
            dynamic dyn = new DynamicProduct();
            dyn.name = "n1"; //call TrySetMember method when name is a privare property
            dyn.ID = 1;
            dyn.ID = dyn.ID + 3;
            dyn.ShowProduct();
        }
    }
}
