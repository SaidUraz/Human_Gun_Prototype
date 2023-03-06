using Zenject;
using UnityEngine;
using GameAssets.Scripts.GunSystem;

namespace GameAssets.Scripts.PlayerSystem.Gun
{
    public class PlayerGunHandlerFacade : MonoBehaviour
    {
        #region Variables

        private PlayerGunHandler _playerGunHandler;

        #endregion Variables

        #region Properties



        #endregion Properties

        #region Awake - OnDisable

        private void Awake()
        {
            Initialize();
        }

        private void OnDisable()
        {
            Terminate();
        }

        #endregion Awake - OnDisable

        #region Functions

        [Inject]
        private void PlayerGunHandlerFacadeConstructor(PlayerGunHandler playerGunHandler)
        {
            _playerGunHandler = playerGunHandler;
        }

        private void Initialize()
        {

        }

        private void Terminate()
        {

        }

        #endregion Functions

        #region Trigger Functions

        private void OnTriggerEnter(Collider collider)
        {
            IHumanCollectable humanCollectable = collider.GetComponent<IHumanCollectable>();
            if (humanCollectable != null)
            {
                _playerGunHandler.HandleGunPart(humanCollectable);
                return;
            }

            IGateCollectable gateCollectable = collider.GetComponent<IGateCollectable>();
            if (gateCollectable != null)
            {
                _playerGunHandler.HandleGunPart(gateCollectable);
                return;
            }

        }

        #endregion Trigger Functions
    }
}