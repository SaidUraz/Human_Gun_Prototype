using TMPro;
using Zenject;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using GameAssets.Scripts.RaycastSystem;
using GameAssets.Scripts.ExtensionSystem;
using GameAssets.Scripts.CurrencySystem.Signals;

namespace GameAssets.Scripts.CurrencySystem.Canvas
{
    public class CurrencyPanelHandler : MonoBehaviour
    {
        #region Variables

        private SignalBus _signalBus;
        private RaycastService _raycastService;

        private Tween _amountTween;

        private double _targetAmount;
        private double _currencyAmount;

        [BoxGroup("Components")][SerializeField] private Image _moneyImage;
        [BoxGroup("Components")][SerializeField] private TextMeshProUGUI _currentAmountText;

        [BoxGroup("Flow Settings")][SerializeField] private double _amountForIcon;
        [BoxGroup("Flow Settings")][SerializeField] private GameObject _moneyIconPrefab;

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

            if (currencyAmountChangedSignal.IsFlow)
            {
                MoneyFlow(new Vector2(Screen.width / 2f, Screen.height / 2f));
            }
            else if (!currencyAmountChangedSignal.IsFlow)
            {
                AddCurrencyWithTween();
            }
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

        private void MoneyFlow(Vector2 screenPoint)
        {
            //Vector2 objectPosition = _raycastService.GetWorldToScreenPoint(moneyWorldPosition);

            GameObject go = Instantiate(_moneyIconPrefab, transform);
            go.transform.position = screenPoint;

            go.transform.DOScale(1f, 0.2f);
            go.transform.DOMove(_moneyImage.transform.position, 1f)
                .OnComplete(()=>
                {
                    AddCurrencyWithTween();
                });
        }

        #endregion Functions
    }
}