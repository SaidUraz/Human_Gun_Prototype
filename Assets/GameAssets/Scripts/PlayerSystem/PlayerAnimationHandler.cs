using Zenject;
using UnityEngine;

namespace GameAssets.Scripts.PlayerSystem
{
    public class PlayerAnimationHandler : IInitializable, ILateDisposable
    {
        #region Variables

        private Animator _animator;

        #endregion Variables

        #region Properties



        #endregion Properties

        #region Functions

        public PlayerAnimationHandler(Animator animator)
        {
            _animator = animator;
        }

        public void Initialize()
        {

        }

        public void LateDispose()
        {
            _animator = null;
        }

        #endregion Functions
    }
}