using UnityEngine;
using Sirenix.OdinInspector;

namespace GameAssets.Scripts.PlayerSystem.Data
{
    [CreateAssetMenu (fileName = "PlayerFireData", menuName = "Scriptable Objects/Player/Data/PlayerFireData")]
    public class PlayerFireData : ScriptableObject
    {
        #region Variables

        [BoxGroup("Ray")][SerializeField] private float _rayMaxDistance;

        [BoxGroup("Data")][SerializeField] private float _fireTimeInterval;

        #endregion Variables

        #region Properties

        public float RayMaxDistance { get => _rayMaxDistance; set => _rayMaxDistance = value; }

        public float FireTimeInterval { get => _fireTimeInterval; set => _fireTimeInterval = value; }

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