using System;

namespace Torens.Domain
{
    public interface ITimeProvider
    {
        DateTime Now { get; }
    }
}