using Xenko.Core;
using Xenko.Core.Mathematics;

namespace Torens.Presentation.ViewModels
{
    [DataContract("ChunkViewModel")]
    [Display("Chunk")]
    public class ChunkViewModel
    {
        public Vector3 Position { get; set; }
    }
}