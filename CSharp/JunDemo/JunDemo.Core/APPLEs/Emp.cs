using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace JunDemo.APPLEs
{
    [Table("APPLEEmp")]
    public class Emp:Entity
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
    }
}
