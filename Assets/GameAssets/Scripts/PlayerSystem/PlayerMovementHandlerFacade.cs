using System;
using Zenject;
using UnityEngine;
using GameAssets.Scripts.CanvasSystem;

namespace GameAssets.Scripts.PlayerSystem
{
    public class PlayerMovementHandlerFacade : MonoBehaviour, IDisposable
    {
        #region Variables

        private bool _isPlayerMovable;

        private SignalBus _signalBus;
        private PlayerMovementHandler _playerMovementHandler;

        #endregion Variables

        #region Properties



        #endregion Properties

        #region Awake - Update - OnDisable

        private void Awake()
        {
            Initialize();
        }

        private void Update()
        {
            MovePlayer();
        }

        private void OnDisable()
        {
            Terminate();
            Dispose();
        }

        #endregion Awake - Update - OnDisable

        #region Functions

        [Inject]
        private void PlayerMovementHandlerFacadeConstructor(SignalBus signalBus, PlayerMovementHandler playerMovementHandler)
        {
            _signalBus = signalBus;
            _playerMovementHandler = playerMovementHandler;
        }

        private void Initialize()
        {
            SubscribeSignals(true);
        }

        private void Terminate()
        {
            SubscribeSignals(false);
        }

        public void Dispose()
        {
            _signalBus = null;
        }

        private void SubscribeSignals(bool subscribe)
        {
            if (subscribe)
            {
                _signalBus.Subscribe<PlayButtonClickedSignal>(OnPlayButtonClickedSignal);
            }
            else if (!subscribe)
            {
                _signalBus.TryUnsubscribe<PlayButtonClickedSignal>(OnPlayButtonClickedSignal);
            }
        }

        private void OnPlayButtonClickedSignal()
        {
            _isPlayerMovable = true;
        }

        private void MovePlayer()
        {
            if (!_isPlayerMovable) return;

            _playerMovementHandler.MovePlayerVertically();
            _playerMovementHandler.MovePlayerHorizontally();
        }

        #endregion Functions
    }
}