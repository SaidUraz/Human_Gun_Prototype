using Zenject;
using UnityEngine;
using Sirenix.OdinInspector;
using GameAssets.Scripts.RaycastSystem;
using GameAssets.Scripts.BulletSystem.Pool;
using GameAssets.Scripts.BulletSystem.Data;
using GameAssets.Scripts.BulletSystem.Factory;

namespace GameAssets.Scripts.Installers
{
    public class GameSceneInstaller : MonoInstaller<GameSceneInstaller>
    {
        #region Variables

        [BoxGroup("Data")][SerializeField] private BulletFactoryData _bulletFactoryData;

        #endregion Variables

        #region Functions

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<BulletPool>().AsSingle();
            Container.BindInterfacesAndSelfTo<RaycastService>().AsSingle();
            Container.BindInterfacesAndSelfTo<BulletFactory>().AsSingle().WithArguments(_bulletFactoryData);
        }

        #endregion Functions
    }
}