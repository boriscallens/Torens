using System;

namespace Torens.Domain
{
    public class MachineTimeProvider : ITimeProvider
    {
        public DateTime Now { get; } = DateTime.UtcNow;
    }
}