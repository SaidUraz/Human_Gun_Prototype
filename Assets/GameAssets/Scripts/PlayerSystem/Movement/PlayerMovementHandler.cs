using Zenject;
using Lean.Touch;
using UnityEngine;
using GameAssets.Scripts.CanvasSystem;
using GameAssets.Scripts.PlayerSystem.Data;

namespace GameAssets.Scripts.PlayerSystem.Movement
{
    public class PlayerMovementHandler : IInitializable, ILateDisposable
    {
        #region Variables

        private Vector3 _targetPosition;

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

        public void MovePlayerHorizontally(LeanFinger leanFinger)
        {
            _targetPosition = _rigidbody.transform.position;
            _targetPosition.x += leanFinger.ScreenDelta.x * _playerMovementData.HorizontalSpeed;
            _targetPosition.x = Mathf.Clamp(_targetPosition.x, _playerMovementData.HorizontalClamp.x, _playerMovementData.HorizontalClamp.y);
            _targetPosition = new Vector3(_targetPosition.x, _rigidbody.transform.position.y, _rigidbody.transform.position.z);

            _rigidbody.transform.position = Vector3.Lerp(_rigidbody.transform.position, _targetPosition, _playerMovementData.HorizontalLerpSpeed);
        }

        #endregion Functions
    }
}