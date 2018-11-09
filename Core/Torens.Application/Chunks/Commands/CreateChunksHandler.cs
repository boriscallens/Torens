using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Torens.Application.Repositories;

namespace Torens.Application.Chunks.Commands
{
    public class CreateChunksHandler : IRequestHandler<CreateChunksCommand, CreateChunksViewModel>
    {
        private readonly IChunkRepository _chunkRepository;

        public CreateChunksHandler(IChunkRepository chunkRepository)
        {
            _chunkRepository = chunkRepository;
        }

        public async Task<CreateChunksViewModel> Handle(CreateChunksCommand command, CancellationToken cancellationToken)
        {
            var chunks = await _chunkRepository.AddChunks(command, cancellationToken);

            return new CreateChunksViewModel
            {
                Chunks = chunks
            };
        }
    }
}
