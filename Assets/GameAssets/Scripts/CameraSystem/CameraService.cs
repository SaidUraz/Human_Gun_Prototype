using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameAssets.Scripts
{
    public class CameraService : MonoBehaviour
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

        private void Initialize()
        {

        }

        private void Terminate()
        {

        }

        #endregion Functions
    }
}