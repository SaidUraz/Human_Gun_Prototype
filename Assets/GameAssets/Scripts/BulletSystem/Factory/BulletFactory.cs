using UnityEngine;
using GameAssets.Scripts.BulletSystem.Data;

namespace GameAssets.Scripts.BulletSystem.Factory
{
    public class BulletFactory : BaseBulletFactory
    {
        #region Variables

        private BulletFactoryData _bulletFactoryData;

        #endregion Variables

        #region Properties



        #endregion Properties

        #region Functions

        public BulletFactory(BulletFactoryData bulletFactoryData) : base()
        {
            _bulletFactoryData = bulletFactoryData;
        }

        public override IBullet Manufacture()
        {
            return GameObject.Instantiate(_bulletFactoryData._bulletPrefab, null, true);
        }

        public override IBullet Manufacture(Transform parent, Vector3 position, Quaternion rotation)
        {
            return GameObject.Instantiate(_bulletFactoryData._bulletPrefab, position, rotation, parent);
        }

        public override IBullet Manufacture(int power, Transform parent, Vector3 position, Quaternion rotation)
        {
            BaseBulletHandler baseBulletHandler = GameObject.Instantiate(_bulletFactoryData._bulletPrefab, position, rotation, parent);
            baseBulletHandler.Power = power;

            return baseBulletHandler;
        }

        #endregion Functions
    }
}