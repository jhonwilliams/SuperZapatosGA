using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SuperZapatos.Models.Partials
{
    [MetadataType(typeof(StoreMetadata))]
    public partial class Store
    {
        public class StoreMetadata
        {

            public System.Guid STORE_ID { get; set; }
            [Display(Name = "Name", Description = "Name")]
            [Required(ErrorMessage = "The Name is required.")]
            public string NAME { get; set; }

            [Display(Name = "Address", Description = "Address")]
            public string ADDRESS { get; set; }
        }
    }
}
