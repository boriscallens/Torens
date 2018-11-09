using Torens.Domain.Entities;

namespace Torens.Application.Repositories
{
    public class WorldRepository : IWorldRepository
    {
        public World GetWorld()
        {
            return new World();
        }
    }
}