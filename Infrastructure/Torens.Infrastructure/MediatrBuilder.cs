using System;
using System.Collections.Generic;
using Autofac;
using MediatR;

namespace Torens.Infrastructure
{
    public class MediatrBuilder
    {
        private readonly ContainerBuilder _builder;
        private readonly List<Type> _markerTypes = new List<Type>();
        private readonly IDictionary<Type, object> _instances = new Dictionary<Type, object>();

        public MediatrBuilder()
        {
            _builder = AutofacConfig.GetBuilder();
        }

        public MediatrBuilder WithRequestMarkerTypes(params Type[] markerTypes)
        {
            _markerTypes.AddRange(markerTypes);
            return this;
        }

        internal MediatrBuilder WithInstance<T>(T instance)
        {
            _instances.Add(typeof(T), instance);
            return this;
        }

        public IMediator Build()
        {
            _builder.RegisterModule(new MediatrModule(_markerTypes.ToArray()));

            foreach (var typeAndInstance in _instances)
            {
                _builder.Register(ctx => typeAndInstance.Value).As(typeAndInstance.Key).SingleInstance();
            }

            return _builder.Build().Resolve<IMediator>();
        }
    }
}
