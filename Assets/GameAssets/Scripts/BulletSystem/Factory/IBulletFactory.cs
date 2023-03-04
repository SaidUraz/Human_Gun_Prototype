using UnityEngine;

namespace GameAssets.Scripts.BulletSystem.Factory
{
    public interface IBulletFactory
    {
        #region Properties



        #endregion Properties

        #region Functions

        public abstract IBullet Manufacture();

        public abstract IBullet Manufacture(Transform parent, Vector3 position, Quaternion rotation);

        public abstract IBullet Manufacture(int power, Transform parent, Vector3 position, Quaternion rotation);

        #endregion Functions
    }
}