using System;
using UnityEngine;
using Sirenix.OdinInspector;
using GameAssets.Scripts.BulletSystem.Data;

namespace GameAssets.Scripts.BulletSystem
{
    public abstract class BaseBulletHandler : MonoBehaviour, IBullet, IDisposable
    {
        #region Events

        private Action<IBullet> onBulletSendToPool;

        #endregion Events

        #region Variables

        [BoxGroup("Data")][SerializeField] protected int power;
        [BoxGroup("Data")][SerializeField] protected BulletSettings bulletSettings;

        [BoxGroup("Components")][SerializeField] protected Rigidbody rigidBody;
        [BoxGroup("Components")][SerializeField] protected CapsuleCollider capsuleCollider;

        #endregion Variables

        #region Properties

        public int Power { get => power; set => power = value; }

        public Action<IBullet> OnBulletSendToPool { get => onBulletSendToPool; set => onBulletSendToPool = value; }

        #endregion Properties

        #region FixedUpdate

        private void FixedUpdate()
        {
            MoveBullet();
        }

        #endregion FixedUpdate

        #region Functions

        public virtual void Activate()
        {
            enabled = true;
            gameObject.SetActive(true);
        }

        public virtual void Deactivate()
        {
            enabled = false;
            gameObject.SetActive(false);
        }

        public virtual void Dispose()
        {
            rigidBody = null;
            capsuleCollider = null;
        }

        protected virtual void SendBackToPool()
        {
            enabled = false;
        }

        protected abstract void MoveBullet();

        public abstract void FireBullet();

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public void SendToPool()
        {
            OnBulletSendToPool?.Invoke(this);

            Deactivate();
        }

        #endregion Functions
    }
}