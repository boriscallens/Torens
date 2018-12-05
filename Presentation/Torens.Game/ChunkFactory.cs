using Xenko.Core;
using Xenko.Core.Mathematics;
using Xenko.Core.Serialization.Contents;
using Xenko.Engine;

namespace Torens.Presentation
{
    public class ChunkFactory
    {
        private readonly ServiceRegistry _serviceRegistry;
        private Prefab _chunkPrefab;
        private IContentManager _contentManager;

        public ChunkFactory(ServiceRegistry serviceRegistry)
        {
            _serviceRegistry = serviceRegistry;
        }
        public Entity Create(Vector3 position)
        {
            _contentManager = _contentManager ?? _serviceRegistry.GetService<IContentManager>();
            _chunkPrefab = _chunkPrefab ?? _contentManager.Load<Prefab>("ChunkPrefab");

            var entity = _chunkPrefab.Instantiate()[0];
            entity.Components.Get<TransformComponent>().Position = position;
            //var chunkComponent = entity.Components.Get<TileComponent>();
            //tileComponent.Id = tile.Id;
            //tileComponent.Column = tile.Position.Column;
            //tileComponent.Row = tile.Position.Row;
            //tileComponent.Type = tile.Type;

            // entity.Transform.Position = new Vector3(tile.Position.Column, tile.Position.Layer, tile.Position.Row);

            return entity;
        }
    }
}