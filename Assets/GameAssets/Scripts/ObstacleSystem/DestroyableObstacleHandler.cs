using TMPro;
using UnityEngine;
using Sirenix.OdinInspector;
using GameAssets.Scripts.BulletSystem;

namespace GameAssets.Scripts.ObstacleSystem
{
    public class DestroyableObstacleHandler : BaseObstacleHandler
    {
        #region Variables

        [BoxGroup("Data")][SerializeField] private int _power;

        [BoxGroup("Components")][SerializeField] private TextMeshPro _powerText;

        #endregion Variables

        #region Properties



        #endregion Properties

        #region Functions

        protected override void Initialize()
        {
            base.Initialize();

            UpdatePowerText();
        }

        protected override void Terminate()
        {
            base.Terminate();
        }

        public override void Dispose()
        {
            base.Dispose();
        }

        private void UpdatePower(IBullet bullet)
        {
            _power = Mathf.Clamp(_power - bullet.Power, 0, _power);
        }

        private void UpdatePowerText()
        {
            _powerText.text = "" + _power;
        }

        private bool IsDestroyable()
        {
            return _power <= 0;
        }

        private void DestroyObject()
        {
            gameObject.SetActive(false);
        }

        private void DestroyObjectIfDestroyable()
        {
            bool isDestroyable = IsDestroyable();

            if (!isDestroyable) return;

            DestroyObject();
        }

        public override void OnTriggerEntered(Collider collider)
        {
            IBullet bullet = collider.GetComponent<IBullet>();

            if (bullet != null)
            {
                UpdatePower(bullet);
                UpdatePowerText();

                DestroyObjectIfDestroyable();

                bullet.SendToPool();
                bullet = null;
            }
        }

        #endregion Functions
    }
}