using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using MediatR;

namespace API.Queries
{
    public static class GetProducts
    {
        //Query
        public record Query() : IRequest<Response>;
        //Handler
        public class Handler : IRequestHandler<Query, Response>
        {
            private readonly IProductRepository _repository;
            public Handler(IProductRepository repository)
            {
                _repository = repository;
            }

            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                var products = await _repository.GetProductsAsync();
                return products == null ? null : new Response(products.ToList());
            }
        }

        //Response
        public record Response(List<Product> products);
    }
}