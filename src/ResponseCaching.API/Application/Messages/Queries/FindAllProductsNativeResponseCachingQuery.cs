using MediatR;
using ResponseCaching.API.Application.DTO;

namespace ResponseCaching.API.Application.Messages.Queries;

public record FindAllProductsResponseCachingQuery : IRequest<List<ProductDTO>>;
