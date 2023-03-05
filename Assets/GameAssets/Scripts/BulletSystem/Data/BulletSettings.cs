using UnityEngine;
using Sirenix.OdinInspector;

namespace GameAssets.Scripts.BulletSystem.Data
{
    [CreateAssetMenu (fileName = "BulletSettings", menuName = "Scriptable Objects/Bullet/Data/BulletSettings")]
    public class BulletSettings : ScriptableObject
    {
        #region Variables

        [BoxGroup("Data")][SerializeField] private float _bulletSpeed;

        #endregion Variables

        #region Properties

        public float BulletSpeed { get => _bulletSpeed; set => _bulletSpeed = value; }

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