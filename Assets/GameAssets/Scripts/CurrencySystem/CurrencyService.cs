using Zenject;
using UnityEngine;
using DG.Tweening;
using GameAssets.Scripts.SaveSystem;
using GameAssets.Scripts.RaycastSystem;
using GameAssets.Scripts.CurrencySystem.Signals;

namespace GameAssets.Scripts.CurrencySystem
{
    public class CurrencyService : IInitializable, ILateDisposable
    {
        #region Variables

        private const string CurrencySaveKey = "CurrencySaveKey";

        private double _targetAmount;
        private double _currencyAmount;

        private Tween _amountTween;
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
            _signalBus.Fire(new CurrencyAmountChangedSignal(_currencyAmount, false));
        }

        public void LateDispose()
        {

        }

        public void AddCurrency(double amount, bool isFlow)
        {
            _currencyAmount += amount;
            _signalBus.Fire(new CurrencyAmountChangedSignal(_currencyAmount, isFlow));
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