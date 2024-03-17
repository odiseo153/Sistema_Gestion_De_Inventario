

namespace Application.Chaching
{
    public sealed class QueryChachingPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IChachedQuery
    {
        
        private readonly IChacheService service;

        public QueryChachingPipelineBehavior(IChacheService _service)
        { 
            this.service = _service;
        }
        
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            return await service.GetOrCreateAsync(
                request.Key,
                _ => next(),
                request.Expitation,
                cancellationToken
                );
        }

    }


}
