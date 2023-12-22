using MediatR;
using System.Text.Json.Serialization;

namespace ResponseCaching.API.Common;

public abstract class Command : IRequest<BaseResult>
{
    [JsonIgnore]
    public BaseResult BaseResult { get; set; }

    protected Command()
    {
        BaseResult = new BaseResult();
    }
}
