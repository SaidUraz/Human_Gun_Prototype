using TMPro;
using Zenject;
using UnityEngine;
using Sirenix.OdinInspector;
using GameAssets.Scripts.CurrencySystem.Signals;

namespace GameAssets.Scripts.CurrencySystem.Canvas
{
    public class CurrencyPanelHandler : MonoBehaviour
    {
        #region Variables

        private SignalBus _signalBus;

        [BoxGroup("Components")][SerializeField] private TextMeshProUGUI _currentAmountText;

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
                _signalBus.Subscribe<CurrencyAmountChangedSignal>(UpdateCurrencyText);
            }
            else if (!subscribe)
            {
                _signalBus.TryUnsubscribe<CurrencyAmountChangedSignal>(UpdateCurrencyText);
            }
        }

        private void UpdateCurrencyText(CurrencyAmountChangedSignal currencyAmountChangedSignal)
        {
            _currentAmountText.text = "" + currencyAmountChangedSignal.CurrencyAmount;
        }

        #endregion Functions
    }
}