using System;
using Zenject;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameAssets.Scripts.BulletSystem;
using GameAssets.Scripts.RaycastSystem;
using GameAssets.Scripts.ObstacleSystem;
using GameAssets.Scripts.BulletSystem.Pool;

namespace GameAssets.Scripts.PlayerSystem.Fire
{
    public class PlayerFireHandler : IInitializable, ILateDisposable
    {
        #region Variables

        private bool _isReadyToFire;

        private float _timer;
        private float _fireTimeInterval;

        private Transform _playerTransform;
        
        private RaycastService _raycastService;
        private PlayerFireData _playerFireData;
        private BulletPool _bulletPool;

        #endregion Variables

        #region Properties

        public bool IsReadyToFire { get => _isReadyToFire; }

        #endregion Properties

        #region Functions

        public PlayerFireHandler(BulletPool bulletPool, RaycastService raycastService, PlayerFireData playerFireData, Transform playerTransform)
        {
            _bulletPool = bulletPool;
            _raycastService = raycastService;
            _playerFireData = playerFireData;
            _playerTransform = playerTransform;
        }

        public void Initialize()
        {
            _timer = 0f;
            _fireTimeInterval = 1f;
        }

        public void LateDispose()
        {
            
        }

        public void FireBullet()
        {
            IBullet bullet = _bulletPool.GetBullet();
            bullet.SetPosition(Vector3.up * 1.1f);
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

            if (_timer > _fireTimeInterval)
            {
                ResetTimer();
                _isReadyToFire = true;
            }
        }

        public bool IsDestroyableObstacleHit()
        {
            DestroyableObstacleHandler obstacle = null;
            obstacle = _raycastService.GetObjectOfTypeWithDirectionNonAlloc<DestroyableObstacleHandler>(_playerTransform.position + Vector3.up * 0.5f, Vector3.forward);

            return obstacle != null;
        }

        public bool IsRaycastable()
        {
            return _raycastService.GetHitCountWithDirectionNonAlloc(_playerTransform.position + Vector3.up * 0.5f, Vector3.forward) > 0;
        }

        #endregion Functions
    }
}