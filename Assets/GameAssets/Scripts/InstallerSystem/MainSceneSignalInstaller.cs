using Zenject;
using GameAssets.Scripts.CanvasSystem;

namespace GameAssets.Scripts.InstallerSystem
{
    public class MainSceneSignalInstaller : Installer<MainSceneSignalInstaller>
    {
        #region Functions

        public override void InstallBindings()
        {
            Container.DeclareSignal<PlayButtonClickedSignal>();
        }

        #endregion Functions
    }
}