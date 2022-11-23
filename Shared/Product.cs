﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcommerce.Shared
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }=String.Empty;
        public string Description { get; set; }=String.Empty;

        public string ImageUrl { get; set; } = string.Empty;
        
        [Column(TypeName ="Decimal(18,2")]
        public decimal Price { get; set; }
    }
}
