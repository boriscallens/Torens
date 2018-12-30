using Torens.Game.ViewModels;
using Xenko.Core;
using Xenko.Core.Serialization.Contents;
using Xenko.Engine;
using Xenko.Graphics;
using Xenko.Rendering;
using Buffer = Xenko.Graphics.Buffer;

namespace Torens.Game
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

        internal Entity Create(ChunkViewModel chunkData)
        {
            _contentManager = _contentManager ?? _serviceRegistry.GetService<IContentManager>();
            _chunkPrefab = _chunkPrefab ?? _contentManager.Load<Prefab>("ChunkPrefab");

            var entity = _chunkPrefab.Instantiate()[0];
            var modelComponent = entity.Components.Get<ModelComponent>();
            var transformComponent = entity.Components.Get<TransformComponent>();

            transformComponent.Position = chunkData.Position;
            modelComponent.Model = CreateModel();

            return entity;
        }

        private Model CreateModel()
        {
            // https://doc.xenko.com/latest/en/manual/scripts/create-a-model-from-code.html
            var indexBuffer = new Buffer();

            var indexBufferBinding = new IndexBufferBinding(indexBuffer, true, 10);
            var vertexBufferBinding = new VertexBufferBinding();
            VertexBufferBinding[] vertexBufferBindings = { vertexBufferBinding };

            var meshDraw = new MeshDraw
            {
                VertexBuffers = vertexBufferBindings,
                IndexBuffer = indexBufferBinding
            };
            ParameterCollection parms = null;
            var mesh = new Xenko.Rendering.Mesh(meshDraw, parms);

            var model = new Model { mesh };

            return model;
        }
    }
}