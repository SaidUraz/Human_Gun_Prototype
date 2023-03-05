using System;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;

namespace GameAssets.Scripts.GunSystem.Data
{
    [Serializable]
    public class GunPartGroupData
    {
        #region Variables

        [BoxGroup("Data")][SerializeField] private List<GunPartData> _gunPartDataList;

        #endregion Variables

        #region Properties



        #endregion Properties

        #region Functions

        public GunPartGroupData(List<GunPartData> gunPartDataList)
        {
            _gunPartDataList = gunPartDataList;
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