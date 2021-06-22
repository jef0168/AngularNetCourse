using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Core.Interfaces;
using Infrastructure.Data;
using MediatR;

namespace API.Queries
{
    public static class GetProductsById
    {
        //Query / Command
        //Al the data we need to execute
        public record Query(int Id) : IRequest<Response>;

        //Handler
        //Business logic to execute. Returns a response
        public class Handler : IRequestHandler<Query, Response>
        {
            private readonly IProductRepository _repository;
            public Handler(IProductRepository repository)
            {
                _repository = repository;

            }
            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                //All the business logic
                var product = await _repository.GetProductByIdAsync(request.Id); // .Products.FirstOrDefault(x => x.Id == request.Id);
                return product == null ? null : new Response(product.Id, product.Name);
            }
        }

        //Response
        //The data we want to return
        public record Response(int Id, string Name);
    }
}