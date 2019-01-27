using Torens.Domain.ValueObjects;
using Xenko.Core;
using Xenko.Core.Mathematics;
using Xenko.Engine;
using Xenko.Engine.Design;

namespace Torens.Game
{
    [DataContract("ChunkComponent")]
    [DefaultEntityComponentProcessor(typeof(ChunkProcessor), ExecutionMode = ExecutionMode.Runtime)]
    [Display("Chunk", Expand = ExpandRule.Once)]
    public class ChunkComponent : EntityComponent
    {
        [DataMember(10)]
        public Int3 OriginPosition { get; set; }
    }
}
