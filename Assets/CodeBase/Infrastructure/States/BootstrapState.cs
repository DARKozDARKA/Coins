using CodeBase.Services.Data;
using CodeBase.Services.Unity;
using CodeBase.StaticData.Strings;
using Zenject;

namespace CodeBase.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private GameStateMachine _stateMachine;
        private ISceneLoader _sceneLoader;
        private IStaticDataService _staticDataService;


        [Inject]
        public void Construct(GameStateMachine stateMachine, ISceneLoader sceneLoader, IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            WarmUp();
            _sceneLoader.LoadAsync(SceneNames.Bootstrap, EnterLoadLevel);
        }

        public void Exit() { }

        private void EnterLoadLevel()
        {
            _stateMachine.Enter<LoadLevelState, string>(SceneNames.Main);
        }

        private void WarmUp()
        {
            _staticDataService.Load();
        }
        
    }
}