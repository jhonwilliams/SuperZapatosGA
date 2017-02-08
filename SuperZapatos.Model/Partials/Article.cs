using System;
using System.ComponentModel.DataAnnotations;

namespace SuperZapatos.Models
{
    [MetadataType(typeof(ArticleMetadata))]
    public partial class Article
    {

        public class ArticleMetadata
        {

            public System.Guid ARTICLE_ID { get; set; }

            [Display(Name = "Name")]
            public string NAME { get; set; }
            [Display(Name = "Description")]
            public string DESCRIPTION { get; set; }

            [Display(Name = "Price")]
            public Nullable<decimal> PRICE { get; set; }

            [Display(Name = "Total In Shelf")]
            public Nullable<decimal> TOTAL_IN_SHELF { get; set; }

            [Display(Name = "Total In Vault")]
            public Nullable<decimal> TOTAL_IN_VAULT { get; set; }

            [Display(Name = "Store")]
            public Nullable<System.Guid> STORE_ID { get; set; }
            
            public virtual Store Store { get; set; }
        }

    }
}
