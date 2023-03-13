using CQRS.Queries.Request;
using CQRS.Queries.Response;
using DataAccess;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Handlers.QueryHandlers
{
    public class GetAllProductQueryHandler:IRequestHandler<GetAllProductQueryRequest,List<GetAllProductQueryResponse>>
    {
        public async Task<List<GetAllProductQueryResponse>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            return ApplicationDbContext.ProductList.Select(x => new GetAllProductQueryResponse
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Quantity = x.Quantity,
                CreateTime = x.CreateTime.ToString(),
                UpdateTime = x.UpdateTime == null ? "" : x.UpdateTime.ToString(),
            }).ToList();

            
        }
    }
}
