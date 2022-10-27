using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.States;
using CodeBase.Tools;
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
                { typeof(BootstrapState), BindState(new BootstrapState()) },
                { typeof(LoadLevelState), BindState(new LoadLevelState()) },
                { typeof(GameLoopState), BindState(new GameLoopState()) }
            };

        private IExitableState BindState<T>(T state) where T : class, IExitableState =>
            state
                .With(_ =>  _container.BindInstance(state).AsSingle())
                .With(_ => _container.Inject(state));
    }
}