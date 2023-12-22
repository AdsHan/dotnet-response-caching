using ResponseCaching.API.Data.DomainObjects;

namespace ResponseCaching.API.Data.Entities;

public class ProductModel : BaseEntity
{

    // EF Construtor
    public ProductModel()
    {

    }

    public string Title { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
}
