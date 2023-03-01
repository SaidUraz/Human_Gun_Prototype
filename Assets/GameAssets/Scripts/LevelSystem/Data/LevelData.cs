using System;
using UnityEngine;
using System.Collections;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using GameAssets.Scripts.SceneSystem;

namespace GameAssets.Scripts.LevelSystem.Data
{
    [CreateAssetMenu (fileName = "LevelData", menuName = "Scriptable Objects/Data/LevelData")]
    public class LevelData : ScriptableObject
    {
        #region Variables

        [BoxGroup("Scene")][SerializeField] private SceneReference _sceneReference;

        #endregion Variables

        #region Properties



        #endregion Properties

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