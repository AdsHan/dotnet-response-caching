using ResponseCaching.API.Application.DTO;
using ResponseCaching.API.Common;

namespace ResponseCaching.API.Application.Messages.Queries;

public record FindAllProductsPipelineBehaviourQuery : ICachedQuery<List<ProductDTO>>
{
    public string Key => "GetAll-PipelineBehaviour";
    public TimeSpan Expiration => TimeSpan.FromSeconds(3600);
}
