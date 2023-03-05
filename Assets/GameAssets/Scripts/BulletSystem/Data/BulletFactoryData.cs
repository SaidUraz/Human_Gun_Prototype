using UnityEngine;
using Sirenix.OdinInspector;
using GameAssets.Scripts.BulletSystem;

namespace GameAssets.Scripts.BulletSystem.Data
{
    [CreateAssetMenu (fileName = "BulletFactoryData", menuName = "Scriptable Objects/Factory/Bullet/Data/BulletFactoryData")]
    public class BulletFactoryData : ScriptableObject
    {
        #region Variables

        [BoxGroup("Data")][SerializeField] public BaseBulletHandler _bulletPrefab;

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

        #endregion Functions
    }
}