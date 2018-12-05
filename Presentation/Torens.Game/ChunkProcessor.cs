using System;
using System.Linq;
using MediatR;
using Torens.Application.Chunks.Commands;
using Torens.Application.Worlds.Queries;
using Xenko.Core.Annotations;
using Xenko.Engine;

namespace Torens.Presentation
{

    public class ChunkProcessor: EntityProcessor<ChunkComponent>
    {
        private IMediator _mediator;

        protected override void OnSystemAdd()
        {
            base.OnSystemAdd();
            _mediator = _mediator ?? Services.GetService<IMediator>();
        }

        protected override void OnEntityComponentAdding(Entity entity, [NotNull] ChunkComponent component, [NotNull] ChunkComponent data)
        {
            base.OnEntityComponentAdding(entity, component, data);
        }
    }
}