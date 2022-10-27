using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.States;

namespace CodeBase.Services.Factory
{
    public interface IStateFactory
    {
        Dictionary<Type, IExitableState> CreateStates();
    }
}