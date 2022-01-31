using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    [Table("Basket")]
    public class Basket
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public int ProductId { get; set; }
        public Product Products { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be bigger than 0")]
        public int Quantity { get; set; } = 1;
        [NotMapped]
        public string Category { get; set; }
        [NotMapped]
        public string ProductName { get; set; }
        [NotMapped]
        public string ProductUri { get; set; }
        [NotMapped]
        public decimal ProductUnitPrice { get; set; }
        [NotMapped]
        public string ProductDescription { get; set; }
        [NotMapped]
        public string ProductCategoryId { get; set; }
        [NotMapped]
        public string Cost { get; set; }
    }
}
