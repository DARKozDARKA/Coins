using CodeBase.Logic.Coin;
using UnityEngine;

namespace CodeBase.Services.Factory
{
    public interface IPrefabFactory
    {
        GameObject CreatePlayer(Vector3 at);
        Coin CreateCoin(Vector3 at);
        GameObject CreateUI();
    }
}