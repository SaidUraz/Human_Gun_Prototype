namespace GameAssets.Scripts
{
    public interface IMoney
    {
        #region Properties

        public double MoneyAmount { get; }

        #endregion Properties

        #region Functions

        public void DestroyMoney();

        #endregion Functions
    }
}