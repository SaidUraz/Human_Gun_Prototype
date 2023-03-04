using UnityEngine;

namespace GameAssets.Scripts.BulletSystem
{
    public class BulletHandler : BaseBulletHandler
    {
        #region Variables


        #endregion Variables

        #region Properties

        

        #endregion Properties

        #region Functions

        public override void Activate()
        {
            base.Activate();
        }

        public override void Deactivate()
        {
            base.Deactivate();
        }

        public override void Dispose()
        {
            base.Dispose();
        }

        protected override void MoveBullet()
        {
            rigidBody.velocity = 10f * Vector3.forward;
        }

        public override void FireBullet()
        {
            enabled = true;
        }

        #endregion Functions
    }
}