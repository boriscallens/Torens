﻿namespace Torens.Domain.Logging
{
    public interface ILogger
    {
        void Debug(object message);
        void Error(object message);
        void Fatal(object message);
        void Info(object message);
        void Warn(object message);
    }
}