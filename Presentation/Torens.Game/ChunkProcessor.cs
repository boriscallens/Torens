using System;
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

        protected override void OnSystemAdd()
        {
            base.OnSystemAdd();
            _mediator = _mediator ?? Services.GetService<IMediator>();
            _graphicsDevice = _graphicsDevice ?? Services.GetService<IGraphicsDeviceService>().GraphicsDevice;
        }
        protected override void OnEntityComponentAdding(Entity entity, [NotNull] ChunkComponent component, [NotNull] ChunkComponent data)
        {
            base.OnEntityComponentAdding(entity, component, data);
            var modelComponent = entity.GetOrCreate<ModelComponent>();

            var chunk = new Chunk(component.OriginPosition);
            var tilesRequest = new GetTilesQuery(chunk.GetPositions().ToArray());
            var tiles = _mediator.Send(tilesRequest).GetAwaiter().GetResult();

            modelComponent.Model = new Model();

            //var model = GetModel(tiles);
            //modelComponent.Model = model;
        }

        private Model GetModel(TileSet tiles)
        {
            var meshDraw = GeometricPrimitive.Cube.New(_graphicsDevice).ToMeshDraw();
            var mesh = new Xenko.Rendering.Mesh { Draw = meshDraw };
            return new Model { mesh };
        }
    }
}