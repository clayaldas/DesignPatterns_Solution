namespace DesignPatterns_ASPNETCore.Models.ViewModels
{
  public class ProductModel
  {
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public short UnitsInStock { get; set; }

    public decimal UnitPrice { get; set; }
  }
}
