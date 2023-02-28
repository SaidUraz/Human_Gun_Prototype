using UnityEngine;
using Sirenix.OdinInspector;

namespace GameAssets.Scripts.PlayerSystem.Data
{
    [CreateAssetMenu(fileName = "PlayerMovementData", menuName = "Scriptable Objects/Player/Data/PlayerMovementData")]
    public class PlayerMovementData : ScriptableObject
    {
        #region Variables

        [BoxGroup("Data")][SerializeField] private float _verticalSpeed;
        [BoxGroup("Data")][SerializeField] private float _horizontalSpeed;

        [BoxGroup("Data")][SerializeField] private float _horizontalLerpSpeed;

        #endregion Variables

        #region Properties

        public float Speed { get => _verticalSpeed; set => _verticalSpeed = value; }
        public float HorizontalSpeed { get => _horizontalSpeed; set => _horizontalSpeed = value; }

        public float HorizontalLerpSpeed { get => _horizontalLerpSpeed; set => _horizontalLerpSpeed = value; }

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