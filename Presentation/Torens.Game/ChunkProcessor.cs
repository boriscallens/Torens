using System.Linq;
using MediatR;
using Torens.Application.Tiles.Queries;
using Torens.Domain.Entities;
using Torens.Game.Mesh;
using Xenko.Engine;
using Xenko.Extensions;
using Xenko.Graphics;
using Xenko.Graphics.GeometricPrimitives;
using Xenko.Rendering;

namespace Torens.Game
{
    public class ChunkProcessor: EntityProcessor<ChunkComponent, TileSet>
    {
        private IMediator _mediator;
        private GraphicsDevice _graphicsDevice;

        public ChunkProcessor():base(typeof(ModelComponent), typeof(TransformComponent)){}

        protected override void OnSystemAdd()
        {
            base.OnSystemAdd();
            _mediator = _mediator ?? Services.GetService<IMediator>();
            _graphicsDevice = _graphicsDevice ?? Services.GetService<IGraphicsDeviceService>().GraphicsDevice;
        }

        protected override TileSet GenerateComponentData(Entity entity, ChunkComponent component)
        {
            var chunk = new Chunk(component.OriginPosition.ToPosition());
            var tilesRequest = new GetTilesQuery(chunk.GetPositions().ToArray());
            return _mediator.Send(tilesRequest).GetAwaiter().GetResult();
        }

        protected override void OnEntityComponentAdding(Entity entity, ChunkComponent component, TileSet data)
        {
            base.OnEntityComponentAdding(entity, component, data);

            var modelComponent = entity.Get<ModelComponent>();
            var transformComponent = entity.Get<TransformComponent>();
            var model = GetModel(data);

            transformComponent.Position = component.OriginPosition.ToVector3();
            modelComponent.Model = model;
        }

        private Model GetModel(TileSet tiles)
        {
            var meshDraw = GeometricPrimitive.Cube.New(_graphicsDevice).ToMeshDraw();
            var mesh = new Xenko.Rendering.Mesh { Draw = meshDraw };
            return new Model { mesh };
        }
    }
}