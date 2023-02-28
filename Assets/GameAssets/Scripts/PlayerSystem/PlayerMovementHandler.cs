using Zenject;
using GameAssets.Scripts.PlayerSystem.Data;

namespace GameAssets.Scripts.PlayerSystem
{
    public class PlayerMovementHandler : IInitializable, ILateDisposable
    {
        #region Variables

        private PlayerMovementData _playerMovementData;

        #endregion Variables

        #region Properties



        #endregion Properties

        #region Functions

        public PlayerMovementHandler(PlayerMovementData playerMovementData)
        {
            _playerMovementData = playerMovementData;
        }

        public void Initialize()
        {

        }

        public void LateDispose()
        {
            _playerMovementData = null;
        }

        #endregion Functions
    }
}