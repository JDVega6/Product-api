using ApiProducts.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProducts.Data.Dtos
{
    public class ProductUpdateDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public EntityTypeOption Type { get; set; }
        public Decimal Value { get; set; }
    }
}
