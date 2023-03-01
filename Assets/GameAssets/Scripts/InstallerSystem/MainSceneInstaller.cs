using Zenject;

namespace GameAssets.Scripts.InstallerSystem
{
    public class MainSceneInstaller : MonoInstaller<MainSceneInstaller>
    {
        #region Variables



        #endregion Variables

        #region Functions

        public override void InstallBindings()
        {
            if(!Container.HasBinding<SignalBus>()) SignalBusInstaller.Install(Container);

            Container.BindInterfacesAndSelfTo<SceneService>().AsSingle();
            Container.BindInterfacesAndSelfTo<LevelService>().AsSingle();

            MainSceneSignalInstaller.Install(Container);
        }

        #endregion Functions
    }
}