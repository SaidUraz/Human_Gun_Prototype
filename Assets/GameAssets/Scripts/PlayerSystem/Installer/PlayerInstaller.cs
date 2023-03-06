using Zenject;
using UnityEngine;
using Sirenix.OdinInspector;
using GameAssets.Scripts.GunSystem.Data;
using GameAssets.Scripts.PlayerSystem.Gun;
using GameAssets.Scripts.PlayerSystem.Fire;
using GameAssets.Scripts.PlayerSystem.Data;
using GameAssets.Scripts.PlayerSystem.Money;
using GameAssets.Scripts.PlayerSystem.Movement;
using GameAssets.Scripts.PlayerSystem.Animation;

namespace GameAssets.Scripts.PlayerSystem
{
    public class PlayerInstaller : MonoInstaller<PlayerInstaller>
    {
        #region Variables

        [BoxGroup("Data")][SerializeField] private PlayerData _playerData;
        [BoxGroup("Data")][SerializeField] private PlayerFireData _playerFireData;
        [BoxGroup("Data")][SerializeField] private PlayerMovementData _playerMovementData;

        [BoxGroup("Data")][SerializeField] private GunSetupData _gunSetupData;

        [BoxGroup("Transforms")][SerializeField] private Transform _playerTransform;
        [BoxGroup("Transforms")][SerializeField] private Transform _bulletFireTransform;
        [BoxGroup("Transforms")][SerializeField] private Transform _gunPartSpawnPivot;

        #endregion Variables

        #region Functions

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlayerHandler>().AsSingle().WithArguments(_playerData);
            Container.BindInterfacesAndSelfTo<PlayerGunHandler>().AsSingle().WithArguments(_gunSetupData);
            Container.BindInterfacesAndSelfTo<PlayerFireHandler>().AsSingle().WithArguments(_playerFireData);
            Container.BindInterfacesAndSelfTo<PlayerMoneyHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerMovementHandler>().AsSingle().WithArguments(_playerMovementData);
            Container.BindInterfacesAndSelfTo<PlayerAnimationHandler>().AsSingle();

            Container.BindInstance(_playerTransform).WithId("PlayerTransform");
            Container.BindInstance(_bulletFireTransform).WithId("BulletFireTransform");
            Container.BindInstance(_gunPartSpawnPivot).WithId("GunPartSpawnPivot");
        }

        #endregion Functions
    }
}