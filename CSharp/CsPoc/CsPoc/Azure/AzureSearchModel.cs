using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Search;
using System.ComponentModel.DataAnnotations;

namespace TERS.Infrastructure.Search.Model
{
    public class AzureSearchModel
    {
        [Key]
        [IsFilterable, IsSortable]
        public string Key { get; set; }

        [IsFilterable]
        public string OldVersionNo { get; set; }

        [IsFilterable]
        public string NewVersionNo { get; set; }
    }
}
