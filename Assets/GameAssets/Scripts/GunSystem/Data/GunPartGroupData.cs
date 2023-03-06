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

        #region Functions

        public GunPartGroupData(List<GunPartData> gunPartDataList)
        {
            _gunPartDataList = gunPartDataList;
        }

        public GunPartData GetGunPartDataByIndex(int index)
        {
            if (_gunPartDataList.Count >= index + 1)
            {
                return _gunPartDataList[index];
            }

            return null;
        }

        #endregion Functions
    }
}