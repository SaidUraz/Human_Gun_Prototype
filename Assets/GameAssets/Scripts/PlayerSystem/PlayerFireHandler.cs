using System;
using Zenject;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameAssets.Scripts.BulletSystem;
using GameAssets.Scripts.RaycastSystem;
using GameAssets.Scripts.ObstacleSystem;
using GameAssets.Scripts.BulletSystem.Pool;
using GameAssets.Scripts.PlayerSystem.Data;

namespace GameAssets.Scripts.PlayerSystem.Fire
{
    public class PlayerFireHandler : IInitializable, ILateDisposable
    {
        #region Variables

        private bool _isReadyToFire;

        private float _timer;

        private Transform _playerTransform;
        private Transform _bulletFireTransform;

        private BulletPool _bulletPool;
        private RaycastService _raycastService;
        private PlayerFireData _playerFireData;

        #endregion Variables

        #region Properties

        public bool IsReadyToFire { get => _isReadyToFire; }

        #endregion Properties

        #region Functions

        public PlayerFireHandler(BulletPool bulletPool, RaycastService raycastService, PlayerFireData playerFireData, [Inject(Id = "PlayerTransform")] Transform playerTransform, [Inject(Id = "BulletFireTransform")] Transform bulletFireTransform)
        {
            _bulletPool = bulletPool;
            _raycastService = raycastService;
            _playerFireData = playerFireData;

            _playerTransform = playerTransform;
            _bulletFireTransform = bulletFireTransform;
        }

        public void Initialize()
        {
            _isReadyToFire = true;

            _timer = 0f;
        }

        public void LateDispose()
        {
            
        }

        public void FireBullet()
        {
            IBullet bullet = _bulletPool.GetBullet();
            bullet.SetPosition(_bulletFireTransform.position);
            bullet.FireBullet();

            _isReadyToFire = false;
        }

        private void ResetTimer()
        {
            _timer = 0f;
        }

        public void Timer()
        {
            if (_isReadyToFire) return;

            _timer += Time.deltaTime;

            if (_timer > _playerFireData.FireTimeInterval)
            {
                ResetTimer();
                _isReadyToFire = true;
            }
        }

        public bool IsDestroyableObstacleHit()
        {
            DestroyableObstacleHandler obstacle = null;
            obstacle = _raycastService.GetObjectOfTypeWithDirectionNonAlloc<DestroyableObstacleHandler>(_bulletFireTransform.position, Vector3.forward, _playerFireData.RayMaxDistance);

            return obstacle != null;
        }

        public bool IsRaycastable()
        {
            return _raycastService.GetHitCountWithDirectionNonAlloc(_bulletFireTransform.position, Vector3.forward, _playerFireData.RayMaxDistance) > 0;
        }

        #endregion Functions
    }
}