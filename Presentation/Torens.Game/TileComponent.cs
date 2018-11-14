using Torens.Domain.ValueObjects;
using Xenko.Core;
using Xenko.Engine;
using Xenko.Engine.Design;

namespace Torens.Presentation
{
    [DataContract("TileComponent")]
    [DefaultEntityComponentProcessor(typeof(TileProcessor))]
    [Display("Tile", Expand = ExpandRule.Once)]
    public class TileComponent : EntityComponent
    {
        public GroundTypes Type { get; set; }
        public int Column { get; set; }
        public int Row { get; set; }
    }
}
