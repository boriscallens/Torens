using MediatR;
using System.Linq;
using Xenko.Core.Annotations;
using Xenko.Engine;

namespace Torens.Presentation
{

    public class WorldProcessor: EntityProcessor<WorldComponent>
    {
        private IMediator _mediator;
        private ChunkFactory _chunkFactory;

        protected override void OnSystemAdd()
        {
            base.OnSystemAdd();
            _mediator = _mediator ?? Services.GetService<IMediator>();
            _chunkFactory = _chunkFactory ?? Services.GetService<ChunkFactory>();
        }

        protected override void OnEntityComponentAdding(Entity entity, [NotNull] WorldComponent component, [NotNull] WorldComponent data)
        {
            base.OnEntityComponentAdding(entity, component, data);
            
            var chunks = data.Chunks
                .Select(chunkData => chunkData.Position * data.ChunkSize)
                .Select(position => _chunkFactory.Create(position));

            entity.Scene.Entities.AddRange(chunks);
        }
    }
}