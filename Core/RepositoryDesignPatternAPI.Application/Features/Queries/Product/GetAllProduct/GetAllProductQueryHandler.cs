﻿using MediatR;
using RepositoryDesignPatternAPI.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDesignPatternAPI.Application.Features.Queries.Product.GetAllProduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
    {
        readonly IProductReadRepository _productReadRepository;

        public GetAllProductQueryHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }

        public async Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            

            return new();
        }
    }
}
