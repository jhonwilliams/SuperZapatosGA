using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperZapatos.Models.DTO
{
    public class ArticleDTO
    {
        public System.Guid ARTICLE_ID { get; set; }
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public Nullable<decimal> PRICE { get; set; }
        public Nullable<decimal> TOTAL_IN_SHELF { get; set; }
        public Nullable<decimal> TOTAL_IN_VAULT { get; set; }
        public Nullable<System.Guid> STORE_ID { get; set; }

        public virtual Store Store { get; set; }
    }
}
