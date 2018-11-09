using System;
using Torens.Domain;

namespace Torens.Application
{
    public class MachineTimeProvider : ITimeProvider
    {
        public DateTime Now { get; } = DateTime.UtcNow;
    }
}