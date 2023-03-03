using System;
using Zenject;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameAssets.Scripts.RaycastSystem;

namespace GameAssets.Scripts.PlayerSystem.Fire
{
    public class PlayerFireHandler : IInitializable, ILateDisposable
    {
        #region Variables

        private RaycastService _raycastService;

        #endregion Variables

        #region Properties



        #endregion Properties

        #region Functions

        public PlayerFireHandler(RaycastService raycastService)
        {
            _raycastService = raycastService;
        }

        public void Initialize()
        {
            
        }

        public void LateDispose()
        {
            
        }

        public void FireBullet()
        {

        }

        public bool IsBulletFirable()
        {
            return false;
        }

        #endregion Functions
    }
}