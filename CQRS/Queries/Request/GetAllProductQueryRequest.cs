﻿using CQRS.Queries.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Queries.Request
{
    public class GetAllProductQueryRequest:IRequest<List<GetAllProductQueryResponse>>
    {
    }
}
