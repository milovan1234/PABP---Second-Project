﻿namespace PABP_Second_Project_API.Models
{
    public class ProductCreateVM
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
    }
}
