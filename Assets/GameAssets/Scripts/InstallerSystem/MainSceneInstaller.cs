using Zenject;

namespace GameAssets.Scripts.Installers
{
    public class MainSceneInstaller : MonoInstaller<MainSceneInstaller>
    {
        #region Variables



        #endregion Variables

        #region Functions

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SceneService>();
            Container.BindInterfacesAndSelfTo<LevelService>();
        }

        #endregion Functions
    }
}