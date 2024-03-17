

using Azure;
using SharedKernel.Domain.RailwayOrientedProgramming;

namespace Application.Chaching
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }

}
