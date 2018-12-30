using Xenko.Core;
using Xenko.Engine;
using Xenko.Engine.Design;

namespace Torens.Game
{
    [DataContract("ChunkComponent")]
    [DefaultEntityComponentProcessor(typeof(ChunkProcessor), ExecutionMode = ExecutionMode.Runtime)]
    [Display("Chunk", Expand = ExpandRule.Once)]
    public class ChunkComponent : EntityComponent
    {
    }
}
