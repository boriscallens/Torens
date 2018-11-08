using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Torens.Application.Worlds.Queries
{
    public class GetWorldQueryHandler : IRequestHandler<GetWorldQuery, WorldViewModel>
    {
        public Task<WorldViewModel> Handle(GetWorldQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new WorldViewModel());
        }
    }
}