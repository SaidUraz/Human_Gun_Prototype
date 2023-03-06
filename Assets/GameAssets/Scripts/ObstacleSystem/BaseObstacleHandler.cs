using System;
using UnityEngine;
using Sirenix.OdinInspector;

namespace GameAssets.Scripts.ObstacleSystem
{
    public abstract class BaseObstacleHandler : MonoBehaviour, IObstacle, IDisposable
    {
        #region Variables

        [BoxGroup("Data")][SerializeField] protected int power;
        [BoxGroup("Components")][SerializeField] protected Collider boxCollider;

        #endregion Variables

        #region Properties

        public int Power { get => power; }

        #endregion Properties

        #region Awake - OnDisable

        private void Awake()
        {
            Initialize();
        }

        private void OnDisable()
        {
            Terminate();
            Dispose();
        }

        #endregion Awake - OnDisable

        #region Functions

        protected virtual void Initialize()
        {

        }

        protected virtual void Terminate()
        {

        }

        public virtual void Dispose()
        {
            boxCollider = null;
        }

        public abstract void OnTriggerEntered(Collider collider);

        private void OnTriggerEnter(Collider collider)
        {
            OnTriggerEntered(collider);
        }

        #endregion Functions
    }
}