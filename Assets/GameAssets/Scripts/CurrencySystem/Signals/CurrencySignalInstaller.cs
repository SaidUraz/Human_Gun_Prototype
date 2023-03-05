using Zenject;

namespace GameAssets.Scripts.CurrencySystem.Signals
{
    public class CurrencySignalInstaller : Installer<CurrencySignalInstaller>
    {
        #region Functions

        public override void InstallBindings()
        {
            Container.DeclareSignal<CurrencyAmountChangedSignal>();
        }

        #endregion Functions
    }
}