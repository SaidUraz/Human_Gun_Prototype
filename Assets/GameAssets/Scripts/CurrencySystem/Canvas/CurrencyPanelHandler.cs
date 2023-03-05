using TMPro;
using Zenject;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;
using GameAssets.Scripts.ExtensionSystem;
using GameAssets.Scripts.CurrencySystem.Signals;

namespace GameAssets.Scripts.CurrencySystem.Canvas
{
    public class CurrencyPanelHandler : MonoBehaviour
    {
        #region Variables

        private SignalBus _signalBus;

        private Tween _amountTween;

        private double _targetAmount;
        private double _currencyAmount;

        [BoxGroup("Components")][SerializeField] private TextMeshProUGUI _currentAmountText;

        #endregion Variables

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
        public void CurrencyPanelHandlerConstructor(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        private void Initialize()
        {
            SubscribeEvents(true);
        }

        private void Terminate()
        {
            SubscribeEvents(false);
        }

        private void SubscribeEvents(bool subscribe)
        {
            if (subscribe)
            {
                _signalBus.Subscribe<CurrencyAmountChangedSignal>(OnCurrencyAmountChanged);
            }
            else if (!subscribe)
            {
                _signalBus.TryUnsubscribe<CurrencyAmountChangedSignal>(OnCurrencyAmountChanged);
            }
        }

        private void OnCurrencyAmountChanged(CurrencyAmountChangedSignal currencyAmountChangedSignal)
        {
            _currencyAmount = currencyAmountChangedSignal.CurrencyAmount;
            AddCurrencyWithTween();
        }

        private void UpdateCurrencyText(double currencyAmount)
        {
            _currentAmountText.text = "" + currencyAmount.AbbrivateNum();
        }

        private void AddCurrencyWithTween(float duration = 1f)
        {
            _amountTween?.Kill();
            _amountTween = DOTween.To(() => _targetAmount, x => _targetAmount = x, _currencyAmount, duration)
                .OnUpdate(() =>
                {
                    UpdateCurrencyText(_targetAmount);
                });
        }

        #endregion Functions
    }
}