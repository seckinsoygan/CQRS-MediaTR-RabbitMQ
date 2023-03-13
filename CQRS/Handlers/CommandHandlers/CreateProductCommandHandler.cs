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
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            ApplicationDbContext.ProductList.Add(new()
            {
                Id = ApplicationDbContext.ProductList.Count + 1,
                Name = request.Name,
                Price = request.Price,
                Quantity = request.Quantity,
                CreateTime = DateTime.Now,
            });

            return new CreateProductCommandResponse
            {
                IsSuccess = true,
                ProductId = ("Product Id " + ApplicationDbContext.ProductList.Count +" Added").ToString(),
                TotalProductCount = ApplicationDbContext.ProductList.Count,
            };
        }
    }
}
