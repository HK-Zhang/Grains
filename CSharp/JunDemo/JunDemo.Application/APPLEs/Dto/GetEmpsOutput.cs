using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.Collections.Generic;

namespace JunDemo.APPLEs.Dto
{
    public class GetEmpsOutput:IOutputDto
    {
        public List<EmpDto> Emps {get; set; }
    }
}
