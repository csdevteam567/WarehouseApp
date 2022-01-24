using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WarehouseApp.Models
{
    public class Good
    {
        [Key]
        public int? GoodId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Feature> Features { get; set; }
    }
}
