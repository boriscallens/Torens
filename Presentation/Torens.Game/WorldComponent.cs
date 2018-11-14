using Xenko.Core;
using Xenko.Engine;
using Xenko.Engine.Design;

namespace Torens.Presentation
{
    [DataContract("WorldComponent")]
    [DefaultEntityComponentProcessor(typeof(WorldProcessor), ExecutionMode = ExecutionMode.Editor | ExecutionMode.Runtime)]
    [Display("World", Expand = ExpandRule.Once)]
    public class WorldComponent : EntityComponent
    {
        public int WorldSize { get; set; } = 1;
        public int ChunkSize { get; set; } = 1;
    }
}
