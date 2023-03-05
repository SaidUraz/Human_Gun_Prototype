using Zenject;
using UnityEngine;
using Sirenix.OdinInspector;
using GameAssets.Scripts.PlayerSystem.Fire;
using GameAssets.Scripts.PlayerSystem.Data;

namespace GameAssets.Scripts.PlayerSystem
{
    public class PlayerInstaller : MonoInstaller<PlayerInstaller>
    {
        #region Variables

        [BoxGroup("Data")][SerializeField] private PlayerData _playerData;
        [BoxGroup("Data")][SerializeField] private PlayerFireData _playerFireData;
        [BoxGroup("Data")][SerializeField] private PlayerMovementData _playerMovementData;

        [BoxGroup("Transforms")][SerializeField] private Transform _playerTransform;
        [BoxGroup("Transforms")][SerializeField] private Transform _bulletFireTransform;

        #endregion Variables

        #region Functions

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlayerHandler>().AsSingle().WithArguments(_playerData);
            Container.BindInterfacesAndSelfTo<PlayerMovementHandler>().AsSingle().WithArguments(_playerMovementData);
            Container.BindInterfacesAndSelfTo<PlayerAnimationHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerFireHandler>().AsSingle().WithArguments(_playerFireData);

            Container.BindInstance(_playerTransform).WithId("PlayerTransform");
            Container.BindInstance(_bulletFireTransform).WithId("BulletFireTransform");
        }

        #endregion Functions
    }
}