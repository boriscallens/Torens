using MediatR;
using Torens.Domain.ValueObjects;

namespace Torens.Application.Worlds.Queries
{
    public class GetWorldQuery: IRequest<WorldViewModel>
    {
        public Seed Seed { get; set; }
        public int ChunkSize { get; set; }
        public int WorldSize { get; set; }
    }
}