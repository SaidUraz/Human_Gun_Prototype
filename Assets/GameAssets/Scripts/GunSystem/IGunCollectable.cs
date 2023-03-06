using GameAssets.Scripts.GunSystem.Data;
using GameAssets.Scripts.GunSystem.Human;

namespace GameAssets.Scripts.GunSystem
{
    public interface IHumanCollectable
    {
        #region Properties

        public int PartCount { get; }
        public GunPartHumanHandler HumanHandler { get; }

        #endregion Properties
    }
}