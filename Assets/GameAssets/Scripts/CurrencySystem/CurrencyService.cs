using Zenject;
using UnityEngine;
using GameAssets.Scripts.SaveSystem;
using GameAssets.Scripts.CurrencySystem.Signals;

namespace GameAssets.Scripts.CurrencySystem
{
    public class CurrencyService : IInitializable, ILateDisposable
    {
        #region Variables

        private const string CurrencySaveKey = "CurrencySaveKey";

        private double _currencyAmount;

        private SignalBus _signalBus;
        private SaveService _saveService;

        #endregion Variables

        #region Properties



        #endregion Properties

        #region Functions

        public CurrencyService(SignalBus signalBus, SaveService saveService)
        {
            _signalBus = signalBus;
            _saveService = saveService;
        }

        public void Initialize()
        {
            _signalBus.Fire(new CurrencyAmountChangedSignal(_currencyAmount));
        }

        public void LateDispose()
        {

        }

        public void AddCurrency(double amount)
        {
            _currencyAmount += amount;
            _signalBus.Fire(new CurrencyAmountChangedSignal(_currencyAmount));
        }

        private void SaveCurrencyAmount()
        {
            _saveService.Save(CurrencySaveKey, _currencyAmount);
        }

        private void LoadCurrencyAmount()
        {
            _currencyAmount = _saveService.Load<double>(CurrencySaveKey);
        }

        #endregion Functions
    }
}