using UnityEngine;

namespace GameAssets.Scripts.CurrencySystem.Signals
{
    public struct CurrencyAmountChangedSignal
    {
        private bool _isFlow;
        public bool IsFlow { get => _isFlow; }

        private double _currencyAmount;
        public double CurrencyAmount { get => _currencyAmount; }

        public CurrencyAmountChangedSignal(double currencyAmount, bool isFlow)
        {
            _isFlow = isFlow;
            _currencyAmount = currencyAmount;
        }
    }
}