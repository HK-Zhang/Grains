using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Search.Models;
using Microsoft.Azure.Search;
using System.ComponentModel.DataAnnotations;

namespace TERS.Infrastructure.Search.Model
{
    //[SerializePropertyNamesAsCamelCase]
    public class CostProjectAzureSearchModel : AzureSearchModel
    {
        [IsFilterable, IsSortable, IsSearchable]
        public string ProjectNo { get; set; }

        [IsSearchable]
        public string ProjectName { get; set; }

        [IsFilterable]
        public string Billable { get; set; }

        [IsFilterable, IsSearchable]
        public string ProjectId { get; set; }

        [IsFilterable, IsSearchable]
        public string CostCenterNo { get; set; }

        [IsFilterable]
        public string OuId { get; set; }

        [IsFilterable]
        public string OuName { get; set; }

        public int EndEpoch { get; set; }

        public int StartEpoch { get; set; }

        [IsFilterable]
        public string Status { get; set; }

        [IsFilterable]
        public string ReadOnly { get; set; }

        [IsFilterable, IsSearchable]
        public string ConstCenterName { get; set; }

        [IsFilterable, IsSearchable]
        public string CustomerId { get; set; }

        [IsSearchable]
        public string AccountName { get; set; }
    }
}
