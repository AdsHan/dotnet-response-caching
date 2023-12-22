using MediatR;
using ResponseCaching.API.Application.DTO;
using ResponseCaching.API.Data.Repositories;

namespace ResponseCaching.API.Application.Messages.Queries;

public class ProductQueryHandler :
    IRequestHandler<FindAllProductsDecoratorPatternQuery, List<ProductDTO>>,
    IRequestHandler<FindAllProductsResponseCachingQuery, List<ProductDTO>>,
    IRequestHandler<FindAllProductsPipelineBehaviourQuery, List<ProductDTO>>
{
    private readonly IProductRepository _productRepository;

    public ProductQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<ProductDTO>> Handle(FindAllProductsDecoratorPatternQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAllAsync();

        return products.Select(x => ProductDTO.FromProduct(x)).ToList();
    }

    public async Task<List<ProductDTO>> Handle(FindAllProductsResponseCachingQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAllAsync();

        return products.Select(x => ProductDTO.FromProduct(x)).ToList();
    }

    public async Task<List<ProductDTO>> Handle(FindAllProductsPipelineBehaviourQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAllAsync();

        return products.Select(x => ProductDTO.FromProduct(x)).ToList();
    }
}
