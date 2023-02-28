using Zenject;
using UnityEngine;
using Sirenix.OdinInspector;
using GameAssets.Scripts.PlayerSystem.Data;

namespace GameAssets.Scripts.PlayerSystem
{
    public class PlayerInstaller : MonoInstaller<PlayerInstaller>
    {
        #region Variables

        [BoxGroup("Player")][SerializeField] private PlayerData _playerData;
        [BoxGroup("Player")][SerializeField] private PlayerMovementData _playerMovementData;

        #endregion Variables

        #region Functions

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlayerHandler>().AsSingle().WithArguments(_playerData);
            Container.BindInterfacesAndSelfTo<PlayerMovementHandler>().AsSingle().WithArguments(_playerMovementData);
            Container.BindInterfacesAndSelfTo<PlayerAnimationHandler>().AsSingle();
        }

        #endregion Functions
    }
}