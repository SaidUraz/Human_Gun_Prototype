using Zenject;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace GameAssets.Scripts.SceneSystem
{
    public class SceneService : IInitializable, ILateDisposable
    {
        #region Variables



        #endregion Variables

        #region Properties



        #endregion Properties

        #region Functions

        public void Initialize()
        {
            LoadSceneAsync().Forget();
        }

        public void LateDispose()
        {
            
        }

        public async UniTask LoadSceneAsync()
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);

            await UniTask.WaitUntil(() => asyncOperation.isDone);

            Scene scene = SceneManager.GetSceneByBuildIndex(2);
            SceneManager.SetActiveScene(scene);
        }

        #endregion Functions
    }
}