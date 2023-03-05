using Zenject;
using UnityEngine;
using Sirenix.OdinInspector;
using GameAssets.Scripts.SaveSystem;
using GameAssets.Scripts.RaycastSystem;
using GameAssets.Scripts.CurrencySystem;
using GameAssets.Scripts.BulletSystem.Pool;
using GameAssets.Scripts.BulletSystem.Data;
using GameAssets.Scripts.BulletSystem.Factory;
using GameAssets.Scripts.CurrencySystem.Signals;

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
            Container.BindInterfacesAndSelfTo<BulletFactory>().AsSingle().WithArguments(_bulletFactoryData);

            Container.BindInterfacesAndSelfTo<SaveService>().AsSingle();
            Container.BindInterfacesAndSelfTo<RaycastService>().AsSingle();
            Container.BindInterfacesAndSelfTo<CurrencyService>().AsSingle();

            CurrencySignalInstaller.Install(Container);
        }

        #endregion Functions
    }
}