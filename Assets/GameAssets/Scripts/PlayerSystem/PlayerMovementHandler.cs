using Zenject;
using UnityEngine;
using GameAssets.Scripts.CanvasSystem;
using GameAssets.Scripts.PlayerSystem.Data;

namespace GameAssets.Scripts.PlayerSystem
{
    public class PlayerMovementHandler : IInitializable, ILateDisposable
    {
        #region Variables

        private SignalBus _signalBus;
        private Rigidbody _rigidbody;
        private PlayerMovementData _playerMovementData;

        #endregion Variables

        #region Properties



        #endregion Properties

        #region Functions

        public PlayerMovementHandler(SignalBus signalBus, Rigidbody rigidbody, PlayerMovementData playerMovementData)
        {
            _signalBus = signalBus;
            _rigidbody = rigidbody;
            _playerMovementData = playerMovementData;
        }

        public void Initialize()
        {
            SubscribeSignals(true);
        }

        public void LateDispose()
        {
            SubscribeSignals(false);

            _signalBus = null;
            _rigidbody = null;
            _playerMovementData = null;
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
            
        }

        public void MovePlayerVertically()
        {
            _rigidbody.velocity = _playerMovementData.VerticalSpeed * Vector3.forward;
        }

        public void MovePlayerHorizontally()
        {
            
        }

        #endregion Functions
    }
}