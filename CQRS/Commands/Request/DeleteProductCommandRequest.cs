using CQRS.Abstract_Requests;
using CQRS.Commands.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Commands.Request
{
    public class DeleteProductCommandRequest:IRequests<DeleteProductCommandResponse>
    {
        public int Id { get; set; }
    }
}
