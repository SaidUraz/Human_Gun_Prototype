using System;
using Zenject;
using UnityEngine;
using Sirenix.OdinInspector;
using GameAssets.Scripts.RaycastSystem;

namespace GameAssets.Scripts.PlayerSystem.Fire
{
    public class PlayerFireHandlerFacade : MonoBehaviour
    {
        #region Variables

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
        private void PlayerFireHandlerFacadeConstructor(PlayerFireHandler playerFireHandler)
        {
            _playerFireHandler = playerFireHandler;
        }

        private void Initialize()
        {

        }

        private void Terminate()
        {

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