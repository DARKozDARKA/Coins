using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.States;
using Zenject;

namespace CodeBase.Services.Factory
{
    public class StateFactory : IStateFactory
    {
        private readonly DiContainer _container;

        public StateFactory(DiContainer diContainer) =>
            _container = diContainer;

        public Dictionary<Type, IExitableState> CreateStates() =>
            new Dictionary<Type, IExitableState>()
            {
                { typeof(BootstrapState), BindState<BootstrapState>() },
                { typeof(LoadLevelState), BindState<LoadLevelState>() },
                { typeof(GameLoopState), BindState<GameLoopState>() }
            };

        private IExitableState BindState<T>() where T : IExitableState
        {
            _container.Bind<T>().AsSingle();
            return _container.Resolve<T>();
        }
    }
}