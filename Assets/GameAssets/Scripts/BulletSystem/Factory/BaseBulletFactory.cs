using UnityEngine;
using GameAssets.Scripts.BulletSystem;

namespace GameAssets.Scripts.BulletSystem.Factory
{
    public abstract class BaseBulletFactory : IBulletFactory
    {
        #region Variables



        #endregion Variables

        #region Properties



        #endregion Properties

        #region Functions

        public BaseBulletFactory()
        {

        }

        public abstract IBullet Manufacture();

        public abstract IBullet Manufacture(Transform parent);

        public abstract IBullet Manufacture(Transform parent, Vector3 position, Quaternion rotation);

        #endregion Functions
    }
}