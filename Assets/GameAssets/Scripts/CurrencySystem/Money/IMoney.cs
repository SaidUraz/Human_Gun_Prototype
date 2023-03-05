using UnityEngine;

namespace GameAssets.Scripts.CurrencySystem
{
    public interface IMoney
    {
        #region Properties

        public double MoneyAmount { get; }
        public Vector3 WorldPosition { get; }

        #endregion Properties

        #region Functions

        public void DestroyMoney();

        #endregion Functions
    }
}