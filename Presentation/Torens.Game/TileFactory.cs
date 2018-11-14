using Torens.Domain.Entities;
using Xenko.Core;
using Xenko.Core.Mathematics;
using Xenko.Core.Serialization.Contents;
using Xenko.Engine;

namespace Torens.Presentation
{
    public class TileFactory
    {
        private readonly ServiceRegistry _serviceRegistry;
        private Prefab _tilePrefab;
        private IContentManager _contentManager;

        public TileFactory(ServiceRegistry serviceRegistry)
        {
            _serviceRegistry = serviceRegistry;
        }
        public Entity Create(Tile tile)
        {
            _contentManager = _contentManager ?? _serviceRegistry.GetService<IContentManager>();
            _tilePrefab = _tilePrefab ?? _contentManager.Load<Prefab>("GroundTiles/PlaceholderPrefab");

            var entity = _tilePrefab.Instantiate()[0];
            entity.Transform.Position = new Vector3(tile.Position.Column, tile.Position.Layer, tile.Position.Row);

            return entity;
        }
    }
}