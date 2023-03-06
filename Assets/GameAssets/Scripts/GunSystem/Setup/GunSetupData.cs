using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;

namespace GameAssets.Scripts.GunSystem.Data
{
    [CreateAssetMenu (fileName = "GunSetupData", menuName = "Scriptable Objects/Gun/Data/GunSetupData")]
    public class GunSetupData : ScriptableObject
    {
        #region Variables

        [SerializeField] private List<GunPartGroupData> _gunPartGroupDataList;

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

        public GunPartGroupData GetGunPartGroupDataByIndex(int index)
        {
            if (_gunPartGroupDataList.Count >= index + 1)
            {
                return _gunPartGroupDataList[index];
            }

            return null;
        }

        public void ScriptableConstructor(List<GunPartGroupData> gunPartGroupDataList)
        {
            _gunPartGroupDataList = gunPartGroupDataList;
        }

        #endregion Functions
    }
}