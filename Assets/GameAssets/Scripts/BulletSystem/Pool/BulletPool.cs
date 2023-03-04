using Zenject;
using System.Collections.Generic;
using GameAssets.Scripts.BulletSystem.Factory;
using UnityEngine;

namespace GameAssets.Scripts.BulletSystem.Pool
{
    public class BulletPool : IInitializable, ILateDisposable
    {
        #region Variables

        private BulletFactory _bulletFactory;

        private Stack<IBullet> _iBulletStack;

        #endregion Variables

        #region Properties



        #endregion Properties

        #region Functions

        public BulletPool(BulletFactory bulletFactory)
        {
            _bulletFactory = bulletFactory;
        }

        public void Initialize()
        {
            _iBulletStack = new Stack<IBullet>();
        }

        public void LateDispose()
        {
            _iBulletStack = null;
        }

        private void OnItemSendToPool(IBullet bullet)
        {
            bullet.OnBulletSendToPool -= OnItemSendToPool;
            Debug.LogError(_iBulletStack.Count);
            _iBulletStack.Push(bullet);
            Debug.LogError(_iBulletStack.Count);
        }

        private IBullet GetBulletFromPool()
        {
            _iBulletStack.TryPop(out IBullet bullet);

            return bullet;
        }

        private IBullet GetBulletFromFactory()
        {
            return _bulletFactory.Manufacture();
        }

        public IBullet GetBullet()
        {
            IBullet bullet = null;

            bullet = GetBulletFromPool();
            if (bullet != null)
            {
                Debug.LogError("Pool");
                bullet.OnBulletSendToPool += OnItemSendToPool;
                bullet.Activate();
                return bullet;
            }

            bullet = GetBulletFromFactory();
            if (bullet != null)
            {
                Debug.LogError("Factory");
                bullet.OnBulletSendToPool += OnItemSendToPool;
                bullet.Activate();
                return bullet;
            }

            return null;
        }

        #endregion Functions
    }
}