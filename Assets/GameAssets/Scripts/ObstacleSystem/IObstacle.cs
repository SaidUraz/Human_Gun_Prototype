using UnityEngine;

namespace GameAssets.Scripts.ObstacleSystem
{
    public interface IObstacle
    {
        #region Properties



        #endregion Properties

        #region Functions

        public abstract void OnTriggerEntered(Collider collider);

        #endregion Functions
    }
}