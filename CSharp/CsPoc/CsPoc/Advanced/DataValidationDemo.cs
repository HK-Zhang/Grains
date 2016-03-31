using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDemo
{
    public class DataValidationDemo
    {
        public void Execute()
        {
            Foo();
        }

        private void Foo()
        {
            Model1 model = new Model1();
            foreach (var item in model.IsValid())
            {
                Console.WriteLine("FieldName:{0} Error Message:{1}", item.FieldName, item.Message);
            }
            Console.ReadLine();
        }
    }



    public class ModelValidationError
    {
        public string FieldName { get; set; }
        public string Message { get; set; }
    }

    public static class DataAnnotationHelper
    {
        public static IEnumerable<ModelValidationError> IsValid<T>(this T o)
        {
            var descriptor = GetTypeDescriptor(typeof(T));

            foreach (PropertyDescriptor propertyDescriptor in descriptor.GetProperties())
            {
                foreach (var validationAttribute in propertyDescriptor.Attributes.OfType<ValidationAttribute>())
                {
                    if (!validationAttribute.IsValid(propertyDescriptor.GetValue(o)))
                    {
                        yield return new ModelValidationError() { FieldName = propertyDescriptor.Name, Message = validationAttribute.FormatErrorMessage(propertyDescriptor.Name) };
                    }
                }
            }
        }
        private static ICustomTypeDescriptor GetTypeDescriptor(Type type)
        {
            return new AssociatedMetadataTypeTypeDescriptionProvider(type).GetTypeDescriptor(type);
        }
    }

    public class Model1
    {
        [Required]
        public string Name { get; set; }

        [Range(1, 100)]
        public int Age { get; set; }
    }
}
