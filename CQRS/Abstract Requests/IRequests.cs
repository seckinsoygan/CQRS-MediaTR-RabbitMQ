using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Abstract_Requests
{
    public interface IRequests<out TResponse> : IRequest<TResponse>
    {
    }
}
