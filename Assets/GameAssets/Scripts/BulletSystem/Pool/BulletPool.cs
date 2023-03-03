using Zenject;
using System.Collections.Generic;
using GameAssets.Scripts.BulletSystem.Factory;

namespace GameAssets.Scripts.BulletSystem.Pool
{
    public class BulletPool : IInitializable, ILateDisposable
    {
        #region Variables

        private BulletFactory _bulletFactory;

        private List<IBullet> _iBulletList;

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
            _iBulletList = new List<IBullet>();
        }

        public void LateDispose()
        {
            _iBulletList = null;
        }

        public void SendItemToPool(IBullet bullet)
        {
            _iBulletList.Add(bullet);
        }

        private IBullet GetBulletFromPool()
        {
            IBullet bullet = null;

            for (int i = 0; i < _iBulletList.Count; i++)
            {
                bullet = _iBulletList[i];

                if (bullet != null)
                {
                    return bullet;
                }
            }

            return null;
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
                _iBulletList.Remove(bullet);
                return bullet;
            }

            bullet = GetBulletFromFactory();
            if (bullet != null)
                return bullet;

            return null;
        }

        #endregion Functions
    }
}