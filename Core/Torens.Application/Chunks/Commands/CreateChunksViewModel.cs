using System.Collections.Generic;
using Torens.Domain.Entities;

namespace Torens.Application.Chunks.Commands
{
    public class CreateChunksViewModel
    {
        public IEnumerable<Chunk> Chunks { get; set; } = new List<Chunk>();
    }
}