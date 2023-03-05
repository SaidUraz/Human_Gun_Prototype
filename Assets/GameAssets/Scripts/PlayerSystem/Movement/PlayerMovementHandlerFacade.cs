using System;
using Zenject;
using Lean.Touch;
using UnityEngine;
using GameAssets.Scripts.CanvasSystem;

namespace GameAssets.Scripts.PlayerSystem.Movement
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
            MovePlayerVertically();
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
            SubscribeEvents(true);
        }

        private void Terminate()
        {
            SubscribeEvents(false);
        }

        public void Dispose()
        {
            _signalBus = null;
        }

        private void SubscribeEvents(bool subscribe)
        {
            if (subscribe)
            {
                LeanTouch.OnFingerUpdate += MovePlayerHorizontally;

                _signalBus.Subscribe<PlayButtonClickedSignal>(OnPlayButtonClickedSignal);
            }
            else if (!subscribe)
            {
                LeanTouch.OnFingerUpdate -= MovePlayerHorizontally;

                _signalBus.TryUnsubscribe<PlayButtonClickedSignal>(OnPlayButtonClickedSignal);
            }
        }

        private void OnPlayButtonClickedSignal()
        {
            enabled = true;
            _isPlayerMovable = true;
        }

        private void MovePlayerVertically()
        {
            if (!_isPlayerMovable) return;

            _playerMovementHandler.MovePlayerVertically();
        }

        private void MovePlayerHorizontally(LeanFinger leanFinger)
        {
            if (!_isPlayerMovable) return;

            _playerMovementHandler.MovePlayerHorizontally(leanFinger);
        }

        #endregion Functions
    }
}