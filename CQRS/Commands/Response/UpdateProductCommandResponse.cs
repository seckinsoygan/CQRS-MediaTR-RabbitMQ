using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Commands.Response
{
    public class UpdateProductCommandResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
