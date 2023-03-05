using System;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;

namespace GameAssets.Scripts.GunSystem.Data
{
    [Serializable]
    public class GunPartData
    {
        #region Variables

        [SerializeField] private Vector3 _position;
        [SerializeField] private Quaternion _rotation;

        [SerializeField] private Material _material;

        #endregion Variables

        #region Properties

        public Material Material { get => _material; }

        #endregion Properties

        #region Functions

        public GunPartData(Material material, Vector3 position, Quaternion rotation)
        {
            _material = material;
            _position = position;
            _rotation = rotation;
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