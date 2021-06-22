using System.Threading;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using MediatR;

namespace API.Commands
{
    public static class AddProduct
    {
        //Command
        public record Command(string Name) : IRequest<int>;

        //Handler
        public class Handler : IRequestHandler<Command, int>
        {
            private readonly StoreContext _context;
            public Handler(StoreContext context){
                _context = context;
            }
            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Products.Add(new Product{Id=4, Name=request.Name});
                return 4;
            }
        }
    }
}