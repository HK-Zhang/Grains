using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using JunDemo.APPLEs;

namespace JunDemo.APPLEs.Dto
{
    [AutoMap(typeof(Emp))]
    public class EmpDto : EntityDto
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
    }
}
