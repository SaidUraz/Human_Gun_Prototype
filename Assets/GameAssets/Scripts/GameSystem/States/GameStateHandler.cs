using System;
using Zenject;
using System.Collections.Generic;

namespace GameAssets.Scripts.GameSystem.States
{
    public class PlayerStateHandler : IInitializable, ILateDisposable
    {
        #region Variables

        private BasePlayerState _currentGameState;

        private List<BasePlayerState> _gameStateList;

        #endregion Variables

        #region Functions

        public PlayerStateHandler(List<BasePlayerState> gameStateList)
        {
            _gameStateList = gameStateList;
        }

        public void Initialize()
        {
            BasePlayerState gameState = null;

            for (int i = 0; i < _gameStateList.Count; i++)
            {
                gameState = _gameStateList[i];

                if (gameState != null)
                {
                    gameState.Initialize();
                }
            }
        }

        public void LateDispose()
        {
            _currentGameState = null;
            BasePlayerState gameState = null;

            for (int i = 0; i < _gameStateList.Count; i++)
            {
                gameState = _gameStateList[i];

                if (gameState != null)
                {
                    gameState.Dispose();
                }
            }
        }

        public void ChangeGameState(Type type)
        {
            DeactivateCurrentGameState();

            _currentGameState = GetGameStateByType(type);

            ActivateCurrentGameState();
        }

        private void ActivateCurrentGameState()
        {
            if (_currentGameState != null)
            {
                _currentGameState.OnStateEnter();
            }
        }

        private void DeactivateCurrentGameState()
        {
            if (_currentGameState != null)
            {
                _currentGameState.OnStateExit();
            }
        }

        private BasePlayerState GetGameStateByType(Type type)
        {
            BasePlayerState gameState = null;

            for (int i = 0; i < _gameStateList.Count; i++)
            {
                gameState = _gameStateList[i];

                if (gameState != null && gameState.GetType() == type)
                {
                    return gameState;
                }
            }

            return null;
        }

        #endregion Functions
    }
}