using UnityEngine;
using GameAssets.Scripts.PlayerSystem;

namespace GameAssets.Scripts.ObstacleSystem
{
    public class ObstacleHandler : BaseObstacleHandler
    {
        #region Variables

        

        #endregion Variables

        #region Properties



        #endregion Properties

        #region Functions

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void Terminate()
        {
            base.Terminate();
        }

        public override void Dispose()
        {
            base.Dispose();
        }

        public override void OnTriggerEntered(Collider collider)
        {
            PlayerHandlerFacade playerHandlerFacade = collider.GetComponent<PlayerHandlerFacade>();

            if (playerHandlerFacade != null)
            {

            }
        }

        #endregion Functions
    }
}