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
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var updateproduct = ApplicationDbContext.ProductList.FirstOrDefault(x => x.Id == request.Id);
            if (updateproduct != null)
            {
                updateproduct.Id = request.Id;
                updateproduct.Name = request.Name;
                updateproduct.Price = request.Price;
                updateproduct.UpdateTime = DateTime.Now;
                updateproduct.Quantity = request.Quantity;

                return new UpdateProductCommandResponse
                {
                    IsSuccess = true,
                    Message = "Güncelleme Başarılı."
                };
            }
            return new UpdateProductCommandResponse { 
                IsSuccess = false,
                Message = "Geçersiz ID..."
            };
            
        }
    }
}
