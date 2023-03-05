using System;
using Zenject;
using GameAssets.Scripts.CurrencySystem;

namespace GameAssets.Scripts.PlayerSystem.Money
{
    public class PlayerMoneyHandler : IInitializable, ILateDisposable
    {
        #region Variables

        private CurrencyService _currencyService;

        #endregion Variables

        #region Properties



        #endregion Properties

        #region Functions

        public PlayerMoneyHandler(CurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        public void Initialize()
        {

        }

        public void LateDispose()
        {
            
        }

        public void CollectMoney(IMoney money)
        {
            _currencyService.AddCurrency(money.MoneyAmount, true);
        }

        #endregion Functions
    }
}