namespace YMYPHybridFirst.Dto;

public class GetAllProductDetailsResponseDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string SupplierName { get; set; }
    public string CategoryName { get; set; }
    public string QuantityPerUnit { get; set; }
    public decimal? UnitPrice { get; set; }
    public int? UnitsInStock { get; set; }
}
