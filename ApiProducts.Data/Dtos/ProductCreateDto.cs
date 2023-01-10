using ApiProducts.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProducts.Data.Dtos
{
    public class ProductCreateDto
    {
        public string Description { get; set; }
        public EntityTypeOption Type { get; set; }
        public Decimal Value { get; set; }
        public DateTime DatePurchase { get; set; }
        public bool Status { get; set; }

        public ProductCreateDto()
        {
            DatePurchase= DateTime.Now;
            Status= true;
        }
    }
}
