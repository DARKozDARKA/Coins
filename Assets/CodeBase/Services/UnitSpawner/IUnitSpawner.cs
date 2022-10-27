using System.Collections.Generic;
using CodeBase.Logic.Coin;
using CodeBase.StaticData.ScriptableObjects;
using UnityEngine;

namespace CodeBase.Services.UnitSpawner
{
    public interface IUnitSpawner
    {
        void SetSpawnArea(Rect areaRect, float height);
        GameObject SpawnPlayer();
        void SetCoinsSpawnData(CoinsSpawnData data);
        List<Coin> SpawnCoins();
        List<Coin> GetCoins();
        GameObject GetPlayer();
    }
}