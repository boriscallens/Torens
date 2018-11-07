using MediatR;

namespace Torens.Application.Tiles.Queries
{
    public class GetChangedTilesHandler: IRequestHandler<GetChangedTilesQuery, TilesViewModel>
    {
        public TilesViewModel Handle(GetChangedTilesQuery message)
        {
            return new TilesViewModel();
        }
    }
}