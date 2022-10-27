using System;
using System.Collections;
using System.Collections.Generic;
using CodeBase.Logic.Coin;
using CodeBase.Services.Data;
using CodeBase.Services.UnitSpawner;
using CodeBase.Services.Unity;
using CodeBase.StaticData.Strings;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace CodeBase.Infrastructure.States
{
    public class GameLoopState : IState
    {
        private int _collectedCoinsAmount;
        private IUnitSpawner _unitSpawner;
        private int _coinsAmount;
        private GameStateMachine _gameStateMachine;

        private ICoroutineRunner _coroutineRunner;

        private int _currentTime;
        
        public Action<int> OnCoinsChanged;
        public Action<int> OnTimerChanged;

        private IEnumerator _gameCoroutine;
        private IStaticDataService _staticDataService;

        [Inject]
        public void Construct(GameStateMachine gameStateMachine, IUnitSpawner unitSpawner,
            ICoroutineRunner coroutineRunner, IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
            _coroutineRunner = coroutineRunner;
            _gameStateMachine = gameStateMachine;
            _unitSpawner = unitSpawner;
        }

        public void Enter()
        {
            Initialize();
            StartGame();
        }

        private void StartGame()
        {
            _gameCoroutine = GameTimer();
            _coroutineRunner.StartCoroutine(_gameCoroutine);
            ResetTimer();
            ResetCoins();
        }

        public void Exit()
        {
            OnTimerChanged -= CheckIfTimeIsOver;
            _coroutineRunner.StopCoroutine(_gameCoroutine);
        }
           

        private void Initialize()
        {
            List<Coin> coins = _unitSpawner.GetCoins();
            _coinsAmount = coins.Count;
            coins.ForEach(_ => _.OnCollected += HandleCoinCollected);
            OnTimerChanged += CheckIfTimeIsOver;
        }

        private void HandleCoinCollected(Coin coin)
        {
            coin.OnCollected -= HandleCoinCollected;
            AddOneCoin();

            if (GameIsOver())
                RestartGame();
        }

        private void RestartGame()
        {
            Object.Destroy(_unitSpawner.GetPlayer());
            _gameStateMachine.Enter<LoadLevelState, string>(SceneNames.Main);
        }

        private bool GameIsOver() =>
            _coinsAmount == _collectedCoinsAmount;

        private void AddOneCoin()
        {
            _collectedCoinsAmount++;
            OnCoinsChanged?.Invoke(_collectedCoinsAmount);
        }

        private void ResetCoins()
        {
            _collectedCoinsAmount = 0;
            OnCoinsChanged?.Invoke(_collectedCoinsAmount);
        }

        private void ResetTimer()
        {
            _currentTime = _staticDataService.GetGameData().PlayTime;
            OnTimerChanged?.Invoke(_currentTime);
        }

        private IEnumerator GameTimer()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                _currentTime--;
                OnTimerChanged?.Invoke(_currentTime);
            }
        }

        private void CheckIfTimeIsOver(int time)
        {
            if (time <= 0)
                RestartGame();
        }
    }
}