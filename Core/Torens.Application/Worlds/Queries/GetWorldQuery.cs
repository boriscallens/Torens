using MediatR;
using Torens.Domain.ValueObjects;

namespace Torens.Application.Worlds.Queries
{
    public class GetWorldQuery: IRequest<WorldViewModel>
    {
        public Seed Seed { get; set; }
    }
}