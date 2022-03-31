﻿namespace api.Models
{
    public class Category
    {

        [Key]
        public int CategoryRowId { get; set; }

        [Required]
        [StringLength(50)]
        public string? CategoryId { get; set; }
        [Required]
        [StringLength(100)]
        public string? CategoryName { get; set; }
        [Required]
        public int BasePrice { get; set; }

        public ICollection<Product>? Products { get; set; }

    }

    public class Product
    {

        [Key]
        public int ProductRowId { get; set; }

        [Required]
        [StringLength(50)]
        public string? ProductId { get; set; }

        [Required]
        [StringLength(100)]
        public string? ProductName { get; set; }
        [Required]
        [StringLength(100)]
        public string? Description { get; set; }
        [Required]
        public int CategoryRowId { get; set; }
        public Category? Category { get; set; }
    }
}
