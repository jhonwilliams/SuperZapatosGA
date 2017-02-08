using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SuperZapatos.Models
{
    [MetadataType(typeof(StoreMetadata))]
    public partial class Store
    {
        public class StoreMetadata
        {
            [Display(Name = "Store")]
            public System.Guid STORE_ID { get; set; }

            [Display(Name = "Store Name")]
            [Required(ErrorMessage = "The Name is required.")]
            public string NAME { get; set; }

            [Display(Name = "Address")]
            public string ADDRESS { get; set; }
        }
    }
}
