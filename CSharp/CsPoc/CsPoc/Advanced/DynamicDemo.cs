using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
//using Microsoft.CSharp.RuntimeBinder;
//using System.Runtime.CompilerServices;

namespace CsPoc
{
    class DynamicDemo
    {
        public void Execute() {
            dynamic dyn = new Product();
            object o = dyn;
            Console.WriteLine(o.GetType().GetProperties().Any(t=>t.Name=="age"));
            Console.WriteLine(o.GetType().GetProperties().Any(t => t.Name == "ID"));

        }

        public void Foo1()
        {
            dynamic dyn = new ExpandoObject();
            dyn.Add("a", 1);
            Console.WriteLine(dyn.a);
        }

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

        public void ExcelDemo()
        {
            Type excelType = Type.GetTypeFromProgID("Excel.Application");
            dynamic excel = Activator.CreateInstance(excelType);

            excel.Visible = true;
            excel.Workbooks.Add();

            dynamic sheet = excel.ActiveSheet;
            Process[] processes = Process.GetProcesses();

            for (int i = 0; i < processes.Length; i++)
            {
                sheet.Cells[i + 1, "A"] = processes[i].ProcessName;
                sheet.Cells[i + 1, "B"] = processes[i].Threads.Count;
            }

        }

        public void XMLDemo()
        {
            var doc = XDocument.Load("Employees.xml");
            foreach (var item in doc.Element("Employees").Elements("Employee"))
            {
                Console.WriteLine(item.Element("FirstName").Value );
            }


            // dynamic demo
            var doc2 = XDocument.Load("Employees.xml").AsExpando();

            foreach (var item in doc2.Employees)
            {
                Console.WriteLine(item.FirstName);
            }
        }



    }

    public static class ExpandoXML
    {
        public static dynamic AsExpando(this XDocument xDocument)
        {
            return CreateExpnado(xDocument.Root);
        }

        private static dynamic CreateExpnado(XElement element)
        { 
            var result = new ExpandoObject() as IDictionary<string,object>;

            if (element.Elements().Any(e => e.HasElements))
            {
                var list = new List<ExpandoObject>();
                result.Add(element.Name.ToString(), list);
                foreach (var item in element.Elements())
                {
                    list.Add(CreateExpnado(item));
                }
            }
            else
            {
                foreach (var item in element.Elements())
                {
                    result.Add(item.Name.ToString(), item.Value);
                }
            }

            return result;
        }
    }
}
