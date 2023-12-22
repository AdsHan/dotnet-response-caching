using ResponseCaching.API.Data.Entities;
using ResponseCaching.API.Data.Enums;

namespace ResponseCaching.API.Application.DTO;

public class ProductDTO
{
    public string Description { get; set; }
    public EntityStatusEnum Status { get; set; }

    public static ProductDTO FromProduct(ProductModel product)
    {
        return new ProductDTO
        {
            Description = product.Description,
            Status = product.Status,
        };
    }
}
