namespace YMYPHybridFirst.Dto;

public class GetAllProductsResponseDTO
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public int UnitsInStock { get; set; }
}
