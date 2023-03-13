using CQRS.Abstract_Requests;
using CQRS.Commands.Request;
using CQRS.Commands.Response;
using DataAccess;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Handlers.CommandHandlers
{
    public class DeleteProductCommandHandler:IRequestHandler<DeleteProductCommandRequest,DeleteProductCommandResponse>
    {
        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var deleteProduct = ApplicationDbContext.ProductList.FirstOrDefault(p => p.Id == request.Id);
            

            if(deleteProduct == null)
            {
                return new DeleteProductCommandResponse
                {
                    IsSuccess = false,
                    Message = "Id ye ait eleman bulunamadı.",
                };
            }
            ApplicationDbContext.ProductList.Remove(deleteProduct);
            return new DeleteProductCommandResponse
            {
                IsSuccess = true,
                Message = "Silme Başarılı...",
            };
        }
    }
}
