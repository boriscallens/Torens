using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Torens.Application.Repositories;

namespace Torens.Application.Tiles.Commands
{
    public class CreateTilesHandler : IRequestHandler<CreateTilesCommand, CreateTilesViewModel>
    {
        private readonly ITilesRepository _tilesRepository;

        public CreateTilesHandler(ITilesRepository tilesRepository)
        {
            _tilesRepository = tilesRepository;
        }

        public async Task<CreateTilesViewModel> Handle(CreateTilesCommand request, CancellationToken cancellationToken)
        {
            var tiles = await _tilesRepository.AddTiles(request);
            return new CreateTilesViewModel { Tiles = tiles };
        }
    }
}