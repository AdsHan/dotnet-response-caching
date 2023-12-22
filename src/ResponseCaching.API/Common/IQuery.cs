using MediatR;

namespace ResponseCaching.API.Common;

public interface ICachedQuery<T> : IRequest<T>, ICachedQuery
{

}

public interface ICachedQuery
{
    string Key { get; }
    TimeSpan Expiration { get; }
}
