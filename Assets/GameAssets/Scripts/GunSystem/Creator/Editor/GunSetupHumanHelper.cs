#if UNITY_EDITOR
using System;
using UnityEngine;
using System.Collections.Generic;
using GameAssets.Scripts.GunSystem.Data;

namespace GameAssets.Scripts.GunSystem.Creator.Editor
{
    public class GunSetupHumanHelper : MonoBehaviour
    {
        #region Functions

        public GunPartData GetGunPartData()
        {
            Material material = GetComponentInChildren<Renderer>().sharedMaterials[0];

            GunPartData gunPartData = new GunPartData(material, transform.position, transform.rotation);

            return gunPartData;
        }

        #endregion Functions
    }
}
#endif