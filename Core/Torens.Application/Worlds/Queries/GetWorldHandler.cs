using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Torens.Application.Chunks.Commands;
using Torens.Domain.ValueObjects;

namespace Torens.Application.Worlds.Queries
{
    public class GetWorldHandler : IRequestHandler<GetWorldQuery, WorldViewModel>
    {
        private readonly IMediator _mediator;

        public GetWorldHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<WorldViewModel> Handle(GetWorldQuery request, CancellationToken cancellationToken)
        {
            var chunksRange = Enumerable.Range(0, request.WorldSize).ToArray();
            var tilesRange = Enumerable.Range(0, request.ChunkSize).ToArray();

            // Could I just do this with a multi dim array?
            var chunkPositions = from x in chunksRange
                                 from y in chunksRange
                                 from z in chunksRange
                                 select new Position(x, 0, z);
            var tilesPositions = from x in tilesRange
                                 from y in tilesRange
                                 from z in tilesRange
                                 select new Position(x, 0, z);

            var createChunksCommand = new CreateChunksCommand(chunkPositions.ToArray());
            var chunksViewModel = await _mediator.Send(createChunksCommand, cancellationToken);

            return new WorldViewModel
            {
            };
        }
    }
}