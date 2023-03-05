using System;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;

namespace GameAssets.Scripts.CurrencySystem
{
    public class MoneyHandler : MonoBehaviour, IDisposable, IMoney
    {
        #region Variables

        private Sequence _idleSequence;

        private float _initialHeight;

        [BoxGroup("Data")][SerializeField] private double _moneyAmount;

        [BoxGroup("Animation Settings")][SerializeField] private float _rotateDuration;
        [BoxGroup("Animation Settings")][SerializeField] private float _yMovementOffset;
        [BoxGroup("Animation Settings")][SerializeField] private float _yMovementDuration;

        #endregion Variables

        #region Properties

        public double MoneyAmount { get => _moneyAmount; }

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

        private void Initialize()
        {
            _initialHeight = transform.position.y;

            StartIdleAnimation();
        }

        private void Terminate()
        {
            _idleSequence?.Kill();
        }

        public void Dispose()
        {
            _idleSequence = null;
        }

        public void DestroyMoney()
        {
            gameObject.SetActive(false);
        }

        private void StartIdleAnimation()
        {
            _idleSequence?.Kill();
            _idleSequence = DOTween.Sequence();
            _idleSequence
                .Join(transform.DOMoveY(_initialHeight + _yMovementOffset, _yMovementDuration).SetEase(Ease.Linear))
                .Join(transform.DORotate(180f * Vector3.up, _rotateDuration / 2f, RotateMode.Fast).SetEase(Ease.Linear).SetRelative())
                .Append(transform.DOMoveY(_initialHeight, _yMovementDuration).SetEase(Ease.Linear))
                .Join(transform.DORotate(180f * Vector3.up, _rotateDuration / 2f, RotateMode.Fast).SetEase(Ease.Linear).SetRelative());

            _idleSequence.SetLoops(-1, LoopType.Restart);
        }

        #endregion Functions
    }
}