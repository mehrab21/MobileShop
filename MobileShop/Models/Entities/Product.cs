﻿using System.ComponentModel.DataAnnotations;

namespace MobileShop.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string Categories { get; set; }
        public decimal Price { get; set; }
        
    }
}
