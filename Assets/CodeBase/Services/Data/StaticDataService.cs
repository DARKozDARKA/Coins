using System.Collections.Generic;
using System.Linq;
using CodeBase.StaticData.ScriptableObjects;
using CodeBase.StaticData.Strings;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CodeBase.Services.Data
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<string, LevelData> _levels = new Dictionary<string, LevelData>();
        private GameData _gameData;

        public void Load()
        {
            _levels = LoadResources<LevelData>(StaticDataPath.LevelsData)
                .ToDictionary(_ => _.SceneName, _ => _);

            _gameData = LoadResource<GameData>(StaticDataPath.GameData);
        }

        public T LoadResource<T>(string path) where T : Object =>
            Resources.Load<T>(path);

        public T[] LoadResources<T>(string path) where T : Object =>
            Resources.LoadAll<T>(path);

        public Dictionary<string, LevelData> GetLevels() =>
            _levels;

        public GameData GetGameData() =>
            _gameData;
    }
}