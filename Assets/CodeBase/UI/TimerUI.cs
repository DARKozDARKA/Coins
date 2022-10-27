using CodeBase.Infrastructure.States;
using CodeBase.Tools;
using UnityEngine;
using Zenject;

namespace CodeBase.UI
{
    public class TimerUI : MonoBehaviour
    {
        [SerializeField]
        private TextChanger _textChanger;
    
        private GameLoopState _gameLoopState;

        [Inject]
        private void Construct(GameLoopState gameLoopState)
        {
            _gameLoopState = gameLoopState;
            _gameLoopState.OnTimerChanged += SetTimerText;
        }

        private void OnDestroy() =>
            _gameLoopState.OnTimerChanged -= SetTimerText;

        private void SetTimerText(int time) => 
            _textChanger.ChangeText(TimeConverter.FromSecondsToTime(time));
    }
}
