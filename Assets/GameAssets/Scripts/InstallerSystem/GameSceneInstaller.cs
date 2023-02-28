using Zenject;
using UnityEngine;
using Sirenix.OdinInspector;
using GameAssets.Scripts.PlayerSystem;
using GameAssets.Scripts.PlayerSystem.Data;

namespace GameAssets.Scripts.Installers
{
    public class GameSceneInstaller : MonoInstaller<GameSceneInstaller>
    {
        #region Variables

        [BoxGroup("Player Data")][SerializeField] private PlayerData _playerData;
        [BoxGroup("Player Data")][SerializeField] private PlayerMovementData _playerMovementData;

        #endregion Variables

        #region Functions

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlayerHandler>();
            Container.BindInterfacesAndSelfTo<PlayerMovementHandler>();
        }

        #endregion Functions
    }
}