namespace GameAssets.Scripts.CurrencySystem.Signals
{
    public struct CurrencyAmountChangedSignal
    {
        private double _currencyAmount;
        public double CurrencyAmount { get => _currencyAmount; }

        public CurrencyAmountChangedSignal(double currencyAmount)
        {
            _currencyAmount = currencyAmount;
        }
    }
}