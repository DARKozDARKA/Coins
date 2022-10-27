using CodeBase.Logic;
using CodeBase.Logic.Coin;
using CodeBase.Logic.Player;
using CodeBase.Services.AssetManagment;
using CodeBase.Services.Data;
using CodeBase.StaticData.ScriptableObjects;
using CodeBase.StaticData.Strings;
using CodeBase.Tools;
using UnityEngine;
using Zenject;

namespace CodeBase.Services.Factory
{
    public class PrefabFactory : IPrefabFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataService _staticDataService;
        private readonly DiContainer _container;

        public PrefabFactory(DiContainer container, IAssetProvider assetProvider, IStaticDataService staticDataService)
        {
            _assetProvider = assetProvider;
            _staticDataService = staticDataService;
            _container = container;
        }

        public GameObject CreatePlayer(Vector3 at) =>
            _assetProvider.Instantiate(PrefabsPath.Player, at)
                .With(_ => _container.InjectGameObject(_))
                .With(_ => _.GetComponentInChildren<PlayerMover>()?
                    .SetMovementSpeed(_staticDataService
                    .LoadResource<PlayerData>(StaticDataPath.PlayerData).MovementSpeed));

        public Coin CreateCoin(Vector3 at) =>
            _assetProvider.Instantiate(PrefabsPath.Coin, at)
                .GetComponent<Coin>();

        public GameObject CreateUI() =>
            _assetProvider.Instantiate(PrefabsPath.UI)
                .With(_ => _container.InjectGameObject(_));
    }
}