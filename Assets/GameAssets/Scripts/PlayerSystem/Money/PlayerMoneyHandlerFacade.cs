using System;
using Zenject;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameAssets.Scripts.CurrencySystem;

namespace GameAssets.Scripts.PlayerSystem.Money
{
    public class PlayerMoneyHandlerFacade : MonoBehaviour
    {
        #region Variables

        private PlayerMoneyHandler _playerMoneyHandler;

        #endregion Variables

        #region Properties



        #endregion Properties

        #region Awake - OnDisable

        private void Awake()
        {
            Initialize();
        }

        private void OnDisable()
        {
            Terminate();
        }

        #endregion Awake - OnDisable

        #region Functions

        [Inject]
        private void PlayerMoneyHandlerFacadeConstructor(PlayerMoneyHandler playerMoneyHandler)
        {
            _playerMoneyHandler = playerMoneyHandler;
        }

        private void Initialize()
        {

        }

        private void Terminate()
        {

        }

        #endregion Functions

        #region Trigger Functions

        private void OnTriggerEnter(Collider collider)
        {
            IMoney money = collider.GetComponent<IMoney>();

            if (money != null)
            {
                _playerMoneyHandler.CollectMoney(money);
                money.DestroyMoney();
            }
        }

        #endregion Trigger Functions
    }
}