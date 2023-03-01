using Zenject;
using UnityEngine;
using GameAssets.Scripts.CanvasSystem;

namespace GameAssets.Scripts.PlayerSystem
{
    public class PlayerAnimationHandler : IInitializable, ILateDisposable
    {
        #region Variables

        private int RunHash;

        private Animator _animator;
        private SignalBus _signalBus;

        #endregion Variables

        #region Properties



        #endregion Properties

        #region Functions

        public PlayerAnimationHandler(Animator animator, SignalBus signalBus)
        {
            _animator = animator;
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            RunHash = Animator.StringToHash("Run");

            SubscribeSignals(true);
        }

        public void LateDispose()
        {
            SubscribeSignals(false);

            _animator = null;
            _signalBus = null;
        }

        private void SubscribeSignals(bool subscribe)
        {
            if (subscribe)
            {
                _signalBus.Subscribe<PlayButtonClickedSignal>(OnPlayButtonClickedSignal);
            }
            else if (!subscribe)
            {
                _signalBus.TryUnsubscribe<PlayButtonClickedSignal>(OnPlayButtonClickedSignal);
            }
        }

        private void OnPlayButtonClickedSignal()
        {
            StartRunAnimation();
        }

        public void StartIdleAnimation()
        {
            
        }

        public void StartRunAnimation()
        {
            _animator.SetBool(RunHash, true);
        }

        #endregion Functions
    }
}