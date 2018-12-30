using Xenko.Core;
using Xenko.Core.Mathematics;

namespace Torens.Game.ViewModels
{
    [DataContract("ChunkViewModel")]
    [Display("Chunk")]
    public class ChunkViewModel
    {
        public Vector3 Position { get; set; }
    }
}