using DAL.Models;

namespace PABP_Second_Project_API.Models
{
    public class ProductVM
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
        public CategoryVM? Category { get; set; }
        public SupplierVM? Supplier { get; set; }
    }
}
