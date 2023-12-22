using MediatR;
using ResponseCaching.API.Application.DTO;

namespace ResponseCaching.API.Application.Messages.Queries;

public record FindAllProductsDecoratorPatternQuery : IRequest<List<ProductDTO>>;