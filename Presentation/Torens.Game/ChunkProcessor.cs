using System.Collections.Generic;
using System.Linq;
using MediatR;
using Torens.Application.Tiles.Queries;
using Torens.Domain.Entities;
using Xenko.Core.Annotations;
using Xenko.Engine;
using Xenko.Extensions;
using Xenko.Graphics;
using Xenko.Graphics.GeometricPrimitives;
using Xenko.Rendering;

namespace Torens.Game
{
    public class ChunkProcessor: EntityProcessor<ChunkComponent>
    {
        private IMediator _mediator;
        private GraphicsDevice _graphicsDevice;
        private readonly TileSet _tiles = new TileSet();
        private List<ModelComponent> _modelComponents = new List<ModelComponent>();
        private bool _redraw;

        protected override void OnSystemAdd()
        {
            base.OnSystemAdd();
            _mediator = _mediator ?? Services.GetService<IMediator>();
            _graphicsDevice = _graphicsDevice ?? Services.GetService<IGraphicsDeviceService>().GraphicsDevice;
        }
        protected override void OnEntityComponentAdding(Entity entity, [NotNull] ChunkComponent component, [NotNull] ChunkComponent data)
        {
            base.OnEntityComponentAdding(entity, component, data);
            

            var chunk = new Chunk(component.OriginPosition);
            var tilesRequest = new GetTilesQuery(chunk.GetPositions().ToArray());
            var tileSet = _mediator.Send(tilesRequest).GetAwaiter().GetResult();
            _tiles.Add(tileSet);

            // this is pretty shit. fix it
            _modelComponents.Add(entity.GetOrCreate<ModelComponent>());
            _redraw = true;
        }

        public override void Draw(RenderContext context)
        {
            base.Draw(context);
            if (!_redraw) return;

            // djeezes :(
            var modelComponent = _modelComponents.First();
            foreach (var mc in _modelComponents.Skip(1))
            {
                mc.Enabled = false;
            }

            modelComponent.Model = GetModel(_tiles);
        }

        private Model GetModel(TileSet tiles)
        {
            var meshDraw = GeometricPrimitive.Cube.New(_graphicsDevice).ToMeshDraw();
            var mesh = new Xenko.Rendering.Mesh { Draw = meshDraw };
            return new Model { mesh };
        }
    }
}