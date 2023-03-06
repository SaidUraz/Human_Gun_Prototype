using Zenject;
using UnityEngine;
using System.Collections.Generic;

namespace GameAssets.Scripts.RaycastSystem
{
    public class RaycastService
    {
        #region Variables

        private Camera _mainCamera;

        #endregion Variables

        #region Functions

        public RaycastService([Inject(Id = "MainCamera")] Camera mainCamera)
        {
            _mainCamera = mainCamera;
        }

        public T GetObjectOfTypeWithDirectionNonAlloc<T>(Vector3 position, Vector3 direction, float maxDistance)
        {
            Ray ray = new Ray(position, direction);
            T requiredObject = default;

            RaycastHit[] raycastHitArray = new RaycastHit[5];
            Physics.RaycastNonAlloc(ray, raycastHitArray, maxDistance);

            if (raycastHitArray.Length > 0)
            {
                for (int i = 0; i < raycastHitArray.Length; i++)
                {
                    if (raycastHitArray[i].collider != null)
                    {
                        requiredObject = raycastHitArray[i].collider.GetComponent<T>();

                        if (requiredObject != null)
                        {
                            break;
                        }
                    }
                }
            }

            return requiredObject;
        }

        public int GetHitCountWithDirectionNonAlloc(Vector3 position, Vector3 direction, float maxDistance)
        {
            Ray ray = new Ray(position, direction);
            
            RaycastHit[] raycastHitArray = new RaycastHit[1];
            return Physics.RaycastNonAlloc(ray, raycastHitArray, maxDistance);
        }

        public Vector2 GetWorldToScreenPoint(Vector3 worldPosition)
        {
            return _mainCamera.WorldToScreenPoint(worldPosition);
        }

        #endregion Functions
    }
}