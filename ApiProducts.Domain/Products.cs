using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProducts.Domain
{
    public enum EntityTypeOption
    {
        Property,
        vehicles,
        land,
        apartments
    }
    public class Products
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public EntityTypeOption Type { get; set; }
        public Decimal Value { get; set; }
        public DateTime DatePurchase { get; set; }
        public bool Status { get; set; }
    }
}
