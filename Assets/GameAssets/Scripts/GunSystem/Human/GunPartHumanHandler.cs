using System;
using DG.Tweening;
using UnityEngine;
using System.Collections;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using GameAssets.Scripts.GunSystem.Data;

namespace GameAssets.Scripts.GunSystem.Human
{
    public class GunPartHumanHandler : MonoBehaviour, IHumanCollectable
    {
        #region Variables

        private Sequence _sequence;

        [BoxGroup("Data")][SerializeField] private int _partCount;

        [BoxGroup("Components")][SerializeField] private Renderer _renderer;
        [BoxGroup("Components")][SerializeField] private Collider _collider;

        #endregion Variables

        #region Properties

        public int PartCount { get => _partCount; }

        public GunPartHumanHandler HumanHandler { get => this; }

        #endregion Properties

        #region Awake - OnDisable

        private void Awake()
        {
            Initialize();
        }

        private void OnDisable()
        {
            Terminate();
        }

        #endregion Awake - OnDisable

        #region Functions

        private void Initialize()
        {

        }

        private void Terminate()
        {

        }

        private void MoveToTargetPosition(Vector3 position, Quaternion rotation)
        {
            _sequence?.Kill();
            _sequence = DOTween.Sequence();
            _sequence
                .Join(transform.DOLocalMove(position, 0.5f))
                .Join(transform.DOLocalRotateQuaternion(rotation, 0.5f));
        }

        public void SetupHuman(GunPartData gunPartData, Transform parent)
        {
            _collider.enabled = false;
            transform.SetParent(parent);

            _renderer.sharedMaterials[0] = gunPartData.Material;

            MoveToTargetPosition(gunPartData.Position, gunPartData.Rotation);
        }

        #endregion Functions
    }
}