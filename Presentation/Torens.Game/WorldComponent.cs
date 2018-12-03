using System.Collections.Generic;
using Torens.Presentation.ViewModels;
using Xenko.Core;
using Xenko.Engine;
using Xenko.Engine.Design;

namespace Torens.Presentation
{
    [DataContract("WorldComponent")]
    [DefaultEntityComponentProcessor(typeof(WorldProcessor), ExecutionMode = ExecutionMode.Runtime)]
    [Display("World", Expand = ExpandRule.Once)]
    public class WorldComponent : EntityComponent
    {
        public int WorldSize { get; set; } = 1;
        public int ChunkSize { get; set; } = 1;

        public List<ChunkViewModel> Chunks { get; set; } = new List<ChunkViewModel>();
    }
}
