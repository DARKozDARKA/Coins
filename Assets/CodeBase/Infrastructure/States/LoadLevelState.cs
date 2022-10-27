using CodeBase.CameraScripts;
using CodeBase.Services.Data;
using CodeBase.Services.Factory;
using CodeBase.Services.UnitSpawner;
using CodeBase.Services.Unity;
using CodeBase.StaticData.ScriptableObjects;
using CodeBase.StaticData.Strings;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace CodeBase.Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private GameStateMachine _gameStateMachine;
        private ISceneLoader _sceneLoader;
        private GameStateMachine _stateMachine;
        private IStaticDataService _staticDataService;
        private IUnitSpawner _unitSpawner;
        private IPrefabFactory _prefabFactory;
        private GameObject _ui;

        [Inject]
        public void Construct(GameStateMachine stateMachine, ISceneLoader sceneLoader,
            IStaticDataService staticDataService, IUnitSpawner unitSpawner, IPrefabFactory prefabFactory)
        {
            _prefabFactory = prefabFactory;
            _unitSpawner = unitSpawner;
            _staticDataService = staticDataService;
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter(string name)
        {
            _sceneLoader.LoadAsync(name, OnLoaded);
        }

        public void Exit() { }

        private void OnLoaded()
        {
            LevelData levleData = _staticDataService.GetLevels()[SceneManager.GetActiveScene().name];
            CoinsSpawnData coinsData = _staticDataService.LoadResource<CoinsSpawnData>(StaticDataPath.CoinsData);

            _unitSpawner.SetSpawnArea(levleData.MapRect, levleData.MapHeight);
            _unitSpawner.SetCoinsSpawnData(coinsData);

            var player = _unitSpawner.SpawnPlayer();
            Camera.main.GetComponent<CameraFollower>()?.SetTarget(player);
            _unitSpawner.SpawnCoins();

            if (_ui == null)
                _ui = _prefabFactory.CreateUI();

            _stateMachine.Enter<GameLoopState>();
        }
    }
}