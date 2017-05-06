using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Search;
using System.ComponentModel.DataAnnotations;

namespace TERS.Infrastructure.Search.Model
{
    public class CostTaskAzureSearchModel : AzureSearchModel
    {
        [IsFilterable, IsSearchable]
        public string ProjectNo { get; set; }

        [IsSearchable]
        public string TaskNo { get; set; }

        [IsFilterable, IsSearchable]
        public string TaskName { get; set; }

        [IsFilterable, IsSearchable, IsSortable]
        public string TaskId { get; set; }

        public int? StartEpoch { get; set; }

        public int? EndEpoch { get; set; }

        [IsFilterable]
        public string Billable { get; set; }

        [IsSearchable]
        public string CustomerId { get; set; }

        [IsSearchable]
        public string AccountName { get; set; }
    }
}
