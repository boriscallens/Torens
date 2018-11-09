using Torens.Application.Repositories;
using Torens.Domain.Entities;
using Xunit;

namespace Torens.Application.Test
{
    public class WorldRepositoryShould
    {
        [Fact]
        public void ReturnAWorld()
        {
            var repo = new WorldRepository();
            var world = repo.GetWorld();

            Assert.IsType<World>(world);
        }

        [Fact]
        public void WorldShouldHaveASeed()
        {
            var repo = new WorldRepository();
            var world = repo.GetWorld();

            Assert.NotNull(world.Seed);
        }

        [Fact]
        public void WorldShouldHaveChunks()
        {
            var repo = new WorldRepository();
            var world = repo.GetWorld();

            Assert.NotEmpty(world.Chunks);
        }
    }
}