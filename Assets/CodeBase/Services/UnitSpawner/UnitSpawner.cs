using System;
using System.Collections.Generic;
using CodeBase.Logic.Coin;
using CodeBase.Services.Factory;
using CodeBase.StaticData.ScriptableObjects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CodeBase.Services.UnitSpawner
{
    public class UnitSpawner : IUnitSpawner
    {
        private readonly IPrefabFactory _prefabFactory;
        private Rect _areaRect;
        private bool _isSpawnAreaSet;
        private float _height;
        private CoinsSpawnData _coinsSpawnData;
        private GameObject _player;

        private List<Coin> _spawnedCoins;

        public UnitSpawner(IPrefabFactory prefabFactory)
        {
            _prefabFactory = prefabFactory;
        }

        public void SetSpawnArea(Rect areaRect, float height)
        {
            _height = height;
            _areaRect = areaRect;
            _isSpawnAreaSet = true;
        }
        
        public void SetCoinsSpawnData(CoinsSpawnData data) => 
            _coinsSpawnData = data;

        public GameObject SpawnPlayer()
        {
            if (_isSpawnAreaSet == false)
                throw new Exception("No spawn area to spawn player");

            return _player = _prefabFactory.CreatePlayer(GetRandomPositionInsideRect(_areaRect, _height));
        }

        public List<Coin> SpawnCoins()
        {
            List<Vector3> spawnPoints = GetCoinsSpawnPoints();
            _spawnedCoins = new List<Coin>();
            
            foreach (var vector3 in spawnPoints)
                _spawnedCoins.Add(_prefabFactory.CreateCoin(vector3));

            return _spawnedCoins;
        }

        public List<Coin> GetCoins() =>
            _spawnedCoins;

        public GameObject GetPlayer() =>
            _player;
        
        private Vector3 GetRandomPositionInsideRect(Rect rect, float height) => 
            new Vector3(rect.x + Random.Range(0, rect.width), height, rect.y + Random.Range(0, rect.height));


        private List<Vector3> GetCoinsSpawnPoints()
        {
            if (_isSpawnAreaSet == false)
                throw new Exception("No spawn area to spawn coins");

            float size = _coinsSpawnData.CoinsSpace;
            float pointScatter = _coinsSpawnData.CoinsScatter;
            
            var result = new List<Vector3>();

            for (int i = 0; i < _areaRect.width / size; i++)
            for (int k = 0; k < _areaRect.height / size; k++)
            {
                Vector2 newPoint = new Vector2(i * size + _areaRect.x, k * size + _areaRect.y); // Get point inside rect
                Vector2 adjustedPoint = newPoint + new Vector2(Random.Range(0, pointScatter), Random.Range(0, pointScatter)); // Randomize point
                if (_areaRect.Contains(adjustedPoint) == false) // if randomized point outside of the border, set regular point inside rect
                    adjustedPoint = newPoint;
                    
                result.Add(new Vector3(adjustedPoint.x, _height, adjustedPoint.y));
            }

            return result;
        }
            
    }
}