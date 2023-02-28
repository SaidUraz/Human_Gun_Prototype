using UnityEngine;
using Zenject;

namespace GameAssets.Scripts.PlayerSystem
{
    public class PlayerMovementHandlerFacade : MonoBehaviour
    {
        #region Variables

        [Inject] private Animator animator;

        #endregion Variables

        #region Properties



        #endregion Properties

        #region Awake - Update - OnDisable

        private void Awake()
        {
            Initialize();
        }

        private void Update()
        {
            if (animator)
            {
                Debug.LogError("notnnull");
            }
        }

        private void OnDisable()
        {
            Terminate();
        }

        #endregion Awake - Update - OnDisable

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