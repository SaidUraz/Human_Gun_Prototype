using TMPro;
using DG.Tweening;
using UnityEngine;
using Sirenix.OdinInspector;
using GameAssets.Scripts.BulletSystem;

namespace GameAssets.Scripts.ObstacleSystem
{
    public class DestroyableObstacleHandler : BaseObstacleHandler
    {
        #region Variables

        private Tween _hitTween;

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
            power = Mathf.Clamp(power - bullet.Power, 0, power);
        }

        private void UpdatePowerText()
        {
            _powerText.text = "" + power;
        }

        private bool IsDestroyable()
        {
            return power <= 0;
        }

        private void PlayHitAnimation()
        {
            _hitTween?.Kill();
            _hitTween = transform.DOShakeScale(0.05f, 0.2f, 1);
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
                PlayHitAnimation();

                DestroyObjectIfDestroyable();

                bullet.SendToPool();
                bullet = null;
            }
        }

        #endregion Functions
    }
}