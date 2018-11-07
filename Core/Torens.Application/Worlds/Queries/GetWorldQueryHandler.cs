using MediatR;

namespace Torens.Application.Worlds.Queries
{
    public class GetWorldQueryHandler : IRequestHandler<GetWorldQuery, WorldViewModel>
    {
        public WorldViewModel Handle(GetWorldQuery message)
        {
            return new WorldViewModel();
        }
    }
}