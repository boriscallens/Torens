using System.Collections.Generic;
using Torens.Presentation.ViewModels;
using Xenko.Core;
using Xenko.Engine;
using Xenko.Engine.Design;

namespace Torens.Presentation
{
    [DataContract("ChunkComponent")]
    [DefaultEntityComponentProcessor(typeof(ChunkProcessor), ExecutionMode = ExecutionMode.Runtime)]
    [Display("Chunk", Expand = ExpandRule.Once)]
    public class ChunkComponent : EntityComponent
    {
    }
}
