using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Abstract_Requests
{
    public interface IRequestHandlers<TRequest , TResponse> where TRequest : IRequests<TResponse>
    {
        Task<TResponse> Handle(TRequest request,CancellationToken cancellationToken);
    }
}
