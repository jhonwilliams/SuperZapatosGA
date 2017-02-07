using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperZapatos.Models.Partials
{
    [MetadataType(typeof(StoreMetadata))]
    public partial class Store
    {
        class StoreMetadata
        {

            public System.Guid STORE_ID { get; set; }
            [DisplayName("Name")]
            [Required(ErrorMessage ="The Name is required.")]
            public string NAME { get; set; }

            [DisplayName("Address")]
            public string ADDRESS { get; set; }
        }
    }
}
