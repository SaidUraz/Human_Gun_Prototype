#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Linq;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using GameAssets.Scripts.GunSystem.Data;

namespace GameAssets.Scripts.GunSystem.Creator.Editor
{
    public class GunSetupCreator : MonoBehaviour
    {
        #region Variables

        public int gunSetupCount;

        public int gunPartGroupCount;
        [FolderPath] public string scriptableSavePath;

        #endregion Variables

        #region Properties



        #endregion Properties

        #region Functions

        [Button]
        private void CreatePartGroups()
        {
            ClearPartGroups();

            GameObject instantiatedGroupHelperGo = null;

            for (int i = 0; i < gunPartGroupCount; i++)
            {
                instantiatedGroupHelperGo = new GameObject($"GroupHelper_{i}");
                instantiatedGroupHelperGo.transform.SetParent(transform);
                instantiatedGroupHelperGo.AddComponent<GunSetupCreatorGroupHelper>();
            }
        }

        private void ClearPartGroups()
        {
            List<GunSetupCreatorGroupHelper> groupHelperList = GetComponentsInChildren<GunSetupCreatorGroupHelper>().ToList();

            for (int i = groupHelperList.Count - 1; i >= 0; i--)
            {
                DestroyImmediate(groupHelperList[i].gameObject);
            }
        }

        [Button]
        private void CreateSetupData()
        {
            GunSetupData gunSetupData = ScriptableObject.CreateInstance<GunSetupData>();

            GunPartGroupData gunPartGroupData = null;
            List<GunPartGroupData> gunPartGroupDataList = new List<GunPartGroupData>();
            List<GunSetupCreatorGroupHelper> gunSetupCreatorGroupHelperList = GetComponentsInChildren<GunSetupCreatorGroupHelper>().ToList();

            for (int i = 0; i < gunSetupCreatorGroupHelperList.Count; i++)
            {
                gunPartGroupData = new GunPartGroupData(gunSetupCreatorGroupHelperList[i].GetGunPartData());
                gunPartGroupDataList.Add(gunPartGroupData);
            }

            gunSetupData.ScriptableConstructor(gunPartGroupDataList);

            AssetDatabase.CreateAsset(gunSetupData, $"{scriptableSavePath}/GunSetupData_{gunSetupCount}.asset");
            gunSetupCount++;

            AssetDatabase.SaveAssets();
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
#endif