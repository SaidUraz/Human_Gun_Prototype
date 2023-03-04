using System;
using UnityEngine;

namespace GameAssets.Scripts.BulletSystem
{
    public interface IBullet : IDisposable
    {
        #region Properties

        public int Power { get; set; }

        #endregion Properties

        #region Functions

        public Action<IBullet> OnBulletSendToPool { get; set; }

        public void Activate();
        public void Deactivate();

        public void SetPosition(Vector3 position);
        public abstract void FireBullet();
        public void SendToPool();

        #endregion Functions
    }
}