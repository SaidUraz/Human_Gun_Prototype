using System;
using Zenject;
using UnityEngine;
using GameAssets.Scripts.RaycastSystem;

namespace GameAssets.Scripts.PlayerSystem.Fire
{
    public class PlayerFireHandlerFacade : MonoBehaviour
    {
        #region Variables

        

        #endregion Variables

        #region Properties



        #endregion Properties

        #region Awake - Update - OnDisable

        private void Awake()
        {
            Initialize();
        }

        private void Update()
        {

        }

        private void OnDisable()
        {
            Terminate();
        }

        #endregion Awake - Update - OnDisable

        #region Functions

        [Inject]
        private void PlayerFireHandlerFacadeConstructor()
        {
            
        }

        private void Initialize()
        {

        }

        private void Terminate()
        {

        }

        #endregion Functions
    }
}