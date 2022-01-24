using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WarehouseApp.Models
{
    public class Feature
    {
        [Key]
        public int? FeatureId { get; set; }

        public string FeatureName { get; set; }

        public virtual ICollection<Good> Goods { get; set; }
    }
}
