using Zenject;
using UnityEngine;
using GameAssets.Scripts.GunSystem;
using GameAssets.Scripts.GunSystem.Data;
using GameAssets.Scripts.ObstacleSystem;

namespace GameAssets.Scripts.PlayerSystem.Gun
{
    public class PlayerGunHandler : IInitializable, ILateDisposable
    {
        #region Variables

        private int _gunProgressIndex;

        private GunSetupData _gunSetupData;

        private Transform _playerTransform;
        private Transform _gunPartSpawnPivot;

        #endregion Variables

        #region Functions

        public PlayerGunHandler(GunSetupData gunSetupData, [Inject(Id = "GunPartSpawnPivot")] Transform gunPartSpawnPivot, [Inject(Id = "PlayerTransform")] Transform playerTransform)
        {
            _gunSetupData = gunSetupData;

            _playerTransform = playerTransform;
            _gunPartSpawnPivot = gunPartSpawnPivot;
        }

        public void Initialize()
        {
            _gunProgressIndex = -1;
        }

        public void LateDispose()
        {
            _gunSetupData = null;
        }

        public void HandleGunPart(IHumanCollectable humanCollectable)
        {
            _gunProgressIndex += humanCollectable.PartCount;

            GunPartGroupData gunPartGroupData = _gunSetupData.GetGunPartGroupDataByIndex(_gunProgressIndex);
            if (gunPartGroupData == null) return;

            GunPartData gunPartData = gunPartGroupData.GetGunPartDataByIndex(_gunProgressIndex);
            if (gunPartData == null) return;

            humanCollectable.HumanHandler.SetupHuman(gunPartData, _playerTransform);
        }

        public void HandleGunPart(IGateCollectable gateCollectable)
        {
            if (gateCollectable.PartCount > 0)
            {
                for (int i = 0; i < gateCollectable.PartCount; i++)
                {
                    _gunProgressIndex++;

                    // Instantiate human and SetupHuman;
                }
            }
            else if (gateCollectable.PartCount < 0)
            {
                // Remove humans according to gunSetupData;
            }
        }

        public void HandleGunPart(IObstacle obstacle)
        {
            _gunProgressIndex -= obstacle.Power;

            // Remove humans according to gunSetupData;
        }

        #endregion Functions
    }
}