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
        [NonNegative(ErrorMessage = "Base price must be Positive value")]
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
        [NonNegative(ErrorMessage = "Base price must be Positive value")]
        public int price { get; set; }
        public Category? Category { get; set; }
    }

    public class CatProd
    {

        //public int CategoryRowId { get; set; }

        //public string? CategoryId { get; set; }

        //public string? CategoryName { get; set; }
        //[NonNegative(ErrorMessage = "Base price must be Positive value")]
        //public int BasePrice { get; set; }
        public Category category { get; set; }
        public List<Product>? Products { get; set; }
    }
}
