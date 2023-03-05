#if UNITY_EDITOR
using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using GameAssets.Scripts.GunSystem.Data;

namespace GameAssets.Scripts.GunSystem.Creator.Editor
{
    public class GunSetupCreatorGroupHelper : MonoBehaviour
    {
        #region Functions

        public List<GunPartData> GetGunPartData()
        {
            List<GunPartData> gunPartDataList = new List<GunPartData>();
            List<GunSetupHumanHelper> gunSetupHumanHelperList = GetComponentsInChildren<GunSetupHumanHelper>().ToList();

            GunSetupHumanHelper gunSetupHumanHelper = null;

            for (int i = 0; i < gunSetupHumanHelperList.Count; i++)
            {
                gunSetupHumanHelper = gunSetupHumanHelperList[i];
                gunPartDataList.Add(gunSetupHumanHelper.GetGunPartData());
            }

            return gunPartDataList;
        }

        #endregion Functions
    }
}
#endif