using UnityEngine;
using Sirenix.OdinInspector;

namespace GameAssets.Scripts
{
    [CreateAssetMenu (fileName = "PlayerFireData", menuName = "Scriptable Objects/Player/Data/PlayerFireData")]
    public class PlayerFireData : ScriptableObject
    {
        #region Variables

        [BoxGroup("Ray")][SerializeField] private float _rayLength;

        #endregion Variables

        #region Properties

        public float RayLength { get => _rayLength; set => _rayLength = value; }

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