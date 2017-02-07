using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperZapatos.Models.DTO
{
    public class StoreDTO
    {
        public System.Guid STORE_ID { get; set; }
        public string NAME { get; set; }

        public string ADDRESS { get; set; }
    }

}
