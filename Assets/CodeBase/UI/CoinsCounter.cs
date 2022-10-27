using CodeBase.Infrastructure.States;
using UnityEngine;
using Zenject;

namespace CodeBase.UI
{
    public class CoinsCounter : MonoBehaviour
    {
        [SerializeField]
        private TextChanger _textChanger;

        private GameLoopState _gameLoopState;

        [Inject]
        private void Construct(GameLoopState gameLoopState)
        {
            _gameLoopState = gameLoopState;
            _gameLoopState.OnCoinsChanged += ChangeCoinsAmount;
        }

        private void OnDestroy() =>
            _gameLoopState.OnCoinsChanged -= ChangeCoinsAmount;

        private void ChangeCoinsAmount(int coins) => 
            _textChanger.ChangeText(coins.ToString());
    }
}