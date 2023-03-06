using Zenject;
using GameAssets.Scripts.PlayerSystem.Data;

namespace GameAssets.Scripts.PlayerSystem
{
    public class PlayerHandler : IInitializable, ILateDisposable
    {
        #region Variables

        private PlayerData _playerData;

        #endregion Variables

        #region Properties



        #endregion Properties

        #region Functions

        public PlayerHandler(PlayerData playerData)
        {
            _playerData = playerData;
        }

        public void Initialize()
        {

        }

        public void LateDispose()
        {
            _playerData = null;
        }

        #endregion Functions
    }
}