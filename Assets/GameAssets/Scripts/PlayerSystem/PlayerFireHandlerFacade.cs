using System;
using Zenject;
using UnityEngine;
using Sirenix.OdinInspector;
using GameAssets.Scripts.CanvasSystem;
using GameAssets.Scripts.RaycastSystem;

namespace GameAssets.Scripts.PlayerSystem.Fire
{
    public class PlayerFireHandlerFacade : MonoBehaviour
    {
        #region Variables

        private SignalBus _signalBus;
        private PlayerFireHandler _playerFireHandler;

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
            FireBulletSequence();
        }

        private void OnDisable()
        {
            Terminate();
        }

        #endregion Awake - Update - OnDisable

        #region Functions

        [Inject]
        private void PlayerFireHandlerFacadeConstructor(SignalBus signalBus, PlayerFireHandler playerFireHandler)
        {
            _playerFireHandler = playerFireHandler;
            _signalBus = signalBus;
        }

        private void Initialize()
        {
            SubscribeEvents(true);
        }

        private void Terminate()
        {
            SubscribeEvents(false);
        }

        private void SubscribeEvents(bool subscribe)
        {
            if (subscribe)
            {
                _signalBus.Subscribe<PlayButtonClickedSignal>(OnPlayButtonClicked);
            }
            else if (!subscribe)
            {
                _signalBus.TryUnsubscribe<PlayButtonClickedSignal>(OnPlayButtonClicked);
            }
        }

        private void OnPlayButtonClicked()
        {
            enabled = true;
        }

        private void FireBulletSequence()
        {
            _playerFireHandler.Timer();

            bool isRaycastable = _playerFireHandler.IsRaycastable();
            if (!isRaycastable) return;

            bool isHit = _playerFireHandler.IsDestroyableObstacleHit();
            if (!isHit) return;

            if (!_playerFireHandler.IsReadyToFire) return;
            _playerFireHandler.FireBullet();
        }

        #endregion Functions
    }
}