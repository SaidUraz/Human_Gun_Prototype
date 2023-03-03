using System;
using UnityEngine;
using Sirenix.OdinInspector;

namespace GameAssets.Scripts.BulletSystem
{
    public class BaseBulletHandler : MonoBehaviour, IBullet, IDisposable
    {
        #region Variables

        protected int power;

        [BoxGroup("Components")][SerializeField] protected Rigidbody rigidBody;
        [BoxGroup("Components")][SerializeField] protected BoxCollider boxCollider;

        #endregion Variables

        #region Properties

        public int Power { get => power; set => power = value; }

        #endregion Properties

        #region Update - OnDestroy

        private void Update()
        {
            
        }

        private void OnDestroy()
        {
            Dispose();
        }

        #endregion Update - OnDestroy

        #region Functions

        protected virtual void Initialize()
        {

        }

        protected virtual void Terminate()
        {

        }

        public virtual void Dispose()
        {
            rigidBody = null;
            boxCollider = null;
        }

        protected virtual void SendBackToPool()
        {

        }

        #endregion Functions
    }
}