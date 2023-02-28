using UnityEngine;
using System.Collections.Generic;

namespace GameAssets.Scripts.RaycastSystem
{
    public class RaycastService
    {
        #region Functions

        public static T GetObjectOfTypeWithinAll<T>(Vector3 fingerPosition, Camera camera)
        {
            Ray ray = new Ray();
            T requiredObject = default;

            ray = camera.ScreenPointToRay(fingerPosition);

            RaycastHit[] raycastHitArray = Physics.RaycastAll(ray, Mathf.Infinity);

            for (int i = 0; i < raycastHitArray.Length; i++)
            {
                requiredObject = raycastHitArray[i].collider.GetComponent<T>();

                if (requiredObject != null)
                {
                    break;
                }
            }

            return requiredObject;
        }

        public static T GetObjectOfTypeWithinAll<T>(int layer, Vector3 fingerPosition, Camera camera)
        {
            Ray ray = new Ray();
            T requiredObject = default;

            ray = camera.ScreenPointToRay(fingerPosition);

            RaycastHit[] raycastHitArray = Physics.RaycastAll(ray, Mathf.Infinity, layer);

            if (raycastHitArray.Length > 0)
            {
                Collider collider = null;

                for (int i = 0; i < raycastHitArray.Length; i++)
                {
                    collider = raycastHitArray[i].collider;

                    if (collider)
                    {
                        requiredObject = collider.GetComponent<T>();
                        break;
                    }
                }
            }

            return requiredObject;
        }

        public static T GetObjectOfType<T>(Vector3 fingerPosition, Camera camera)
        {
            Ray ray = new Ray();
            T requiredObject = default;

            ray = camera.ScreenPointToRay(fingerPosition);

            if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity))
            {
                if (raycastHit.collider)
                {
                    requiredObject = raycastHit.collider.GetComponent<T>();
                }
            }

            return requiredObject;
        }

        public static T GetObjectOfType<T>(int layer, Vector3 fingerPosition, Camera camera)
        {
            Ray ray = new Ray();
            T requiredObject = default;

            ray = camera.ScreenPointToRay(fingerPosition);

            if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, layer))
            {
                if (raycastHit.collider)
                {
                    requiredObject = raycastHit.collider.GetComponent<T>();
                }
            }

            return requiredObject;
        }

        public static T GetObjectOfTypeInChildren<T>(int layer, Vector3 fingerPosition, Camera camera)
        {
            Ray ray = new Ray();
            T requiredObject = default;

            ray = camera.ScreenPointToRay(fingerPosition);

            if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, layer))
            {
                if (raycastHit.collider)
                {
                    requiredObject = raycastHit.collider.GetComponentInChildren<T>();
                }
            }

            return requiredObject;
        }

        public static T GetObjectOfTypeInParent<T>(int layer, Vector3 fingerPosition, Camera camera)
        {
            Ray ray = new Ray();
            T requiredObject = default;

            ray = camera.ScreenPointToRay(fingerPosition);

            if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, layer))
            {
                if (raycastHit.collider)
                {
                    requiredObject = raycastHit.collider.GetComponentInParent<T>();
                }
            }

            return requiredObject;
        }

        public static List<T> GetObjectsOfType<T>(int layer, Vector3 fingerPosition, Camera camera)
        {
            Ray ray = new Ray();
            List<T> requiredObjectList = new List<T>();

            ray = camera.ScreenPointToRay(fingerPosition);

            RaycastHit[] raycastHitArray = Physics.RaycastAll(ray, Mathf.Infinity, layer);

            if (raycastHitArray.Length > 0)
            {
                Collider collider = null;

                for (int i = 0; i < raycastHitArray.Length; i++)
                {
                    collider = raycastHitArray[i].collider;

                    if (collider)
                    {
                        requiredObjectList.Add(collider.GetComponent<T>());
                    }
                }
            }

            return requiredObjectList;
        }

        public static T GetObjectOfTypeFromTransform<T>(int layer, Vector3 offset, Transform transform, Vector3 direction)
        {
            Ray ray = new Ray();
            T requiredObject = default(T);
            List<T> objectList = new List<T>();

            ray = new Ray(transform.position + offset, direction);

            RaycastHit[] raycastHitArray = Physics.RaycastAll(ray, Mathf.Infinity, layer);

            if (raycastHitArray.Length > 0)
            {
                Collider collider = null;

                for (int i = 0; i < raycastHitArray.Length; i++)
                {
                    collider = raycastHitArray[i].collider;

                    if (collider)
                    {
                        requiredObject = collider.GetComponent<T>();
                        break;

                    }
                }
            }

            return requiredObject;
        }

        public static List<T> GetObjectsOfTypeFromTransform<T>(int layer, Vector3 offset, Transform transform, Vector3 direction)
        {
            Ray ray = new Ray();
            List<T> requiredObjectList = new List<T>();

            ray = new Ray(transform.position + offset, direction);

            RaycastHit[] raycastHitArray = Physics.RaycastAll(ray, Mathf.Infinity, layer);

            if (raycastHitArray.Length > 0)
            {
                Collider collider = null;

                for (int i = 0; i < raycastHitArray.Length; i++)
                {
                    collider = raycastHitArray[i].collider;

                    if (collider)
                    {
                        requiredObjectList.Add(collider.GetComponent<T>());
                    }
                }
            }

            return requiredObjectList;
        }

        public static T GetObjectOfTypeByRaycastingWithDirection<T>(GameObject gameObject, Vector3 direction)
        {
            Ray ray = new Ray();
            T requiredObject = default;

            ray = new Ray(gameObject.transform.position, direction);

            RaycastHit[] raycastHitArray = Physics.RaycastAll(ray, Mathf.Infinity);

            if (raycastHitArray != null && raycastHitArray.Length > 0)
            {
                for (int i = 0; i < raycastHitArray.Length; i++)
                {
                    if (raycastHitArray[i].collider.GetComponent<T>() != null)
                    {
                        requiredObject = raycastHitArray[i].collider.GetComponent<T>();
                        break;
                    }
                }
            }

            return requiredObject;
        }

        public static T GetObjectOfTypeByRaycastingWithDirection<T>(int layer, GameObject gameObject, Vector3 direction)
        {
            Ray ray = new Ray();
            T requiredObject = default;

            ray = new Ray(gameObject.transform.position, direction);

            if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, layer))
            {
                if (raycastHit.collider)
                {
                    requiredObject = raycastHit.collider.GetComponent<T>();
                }
            }

            return requiredObject;
        }

        public static T GetObjectOfTypeByRaycastingWithDirectionParent<T>(GameObject gameObject, Vector3 direction)
        {
            Ray ray = new Ray();
            T requiredObject = default;

            ray = new Ray(gameObject.transform.position, direction);

            if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity))
            {
                if (raycastHit.collider)
                {
                    requiredObject = raycastHit.collider.GetComponentInParent<T>();
                }
            }

            return requiredObject;
        }

        public static T GetObjectOfTypeByRaycastingWithDirectionWithinAll<T>(int layer, GameObject gameObject, Vector3 direction)
        {
            Ray ray = new Ray();
            T requiredObject = default;

            ray = new Ray(gameObject.transform.position, direction);

            RaycastHit[] raycastHitArray = Physics.RaycastAll(ray, Mathf.Infinity, layer);

            if (raycastHitArray.Length > 0)
            {
                for (int i = 0; i < raycastHitArray.Length; i++)
                {
                    if (raycastHitArray[i].collider)
                    {
                        requiredObject = raycastHitArray[i].collider.GetComponent<T>();

                        if (requiredObject != null)
                        {
                            return requiredObject;
                        }
                    }
                }
            }

            return requiredObject;
        }

        public static T GetObjectOfTypeByRaycastingWithDirectionWithinAll<T>(GameObject gameObject, Vector3 direction)
        {
            Ray ray = new Ray();
            T requiredObject = default;

            ray = new Ray(gameObject.transform.position, direction);

            RaycastHit[] raycastHitArray = Physics.RaycastAll(ray, Mathf.Infinity);

            if (raycastHitArray.Length > 0)
            {
                for (int i = 0; i < raycastHitArray.Length; i++)
                {
                    if (raycastHitArray[i].collider)
                    {
                        requiredObject = raycastHitArray[i].collider.GetComponent<T>();

                        if (requiredObject != null)
                        {
                            return requiredObject;
                        }
                    }
                }
            }

            return requiredObject;
        }

        public static Vector3 GetHitPoint(Vector3 fingerPosition, Camera camera)
        {
            Ray ray = new Ray();
            Vector3 hitPoint = Vector3.zero;

            ray = camera.ScreenPointToRay(fingerPosition);

            bool didHit = Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity);

            if (didHit)
            {
                hitPoint = hit.point;
            }

            return hitPoint;
        }

        public static Vector3 GetHitPoint<T>(Vector3 fingerPosition, Camera camera)
        {
            Ray ray = new Ray();
            Vector3 hitPoint = Vector3.zero;

            ray = camera.ScreenPointToRay(fingerPosition);

            RaycastHit[] raycastHitArray = Physics.RaycastAll(ray, Mathf.Infinity);

            for (int i = 0; i < raycastHitArray.Length; i++)
            {
                if (raycastHitArray[i].collider.GetComponent<T>() != null && raycastHitArray[i].collider)
                {
                    hitPoint = raycastHitArray[i].point;
                }
            }

            return hitPoint;
        }

        public static Vector3 GetHitPointByDirectionFromPosition(Vector3 center, Vector3 direction)
        {
            Ray ray = new Ray();
            Vector3 hitPoint = Vector3.zero;

            ray = new Ray(center, direction);

            bool didHit = Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity);

            if (didHit)
            {
                hitPoint = hit.point;
            }

            return hitPoint;
        }

        public static Vector3 GetSurfaceNormal(Vector3 fingerPosition, Camera camera)
        {
            Ray ray = new Ray();
            Vector3 normal = Vector3.zero;

            ray = camera.ScreenPointToRay(fingerPosition);

            bool didHit = Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity);

            if (didHit)
            {
                normal = hit.normal;
            }

            return normal;
        }

        public static Vector3 GetSurfaceNormal<T>(Vector3 fingerPosition, Camera camera)
        {
            Ray ray = new Ray();
            Vector3 normal = Vector3.zero;

            ray = camera.ScreenPointToRay(fingerPosition);

            RaycastHit[] raycastHitArray = Physics.RaycastAll(ray, Mathf.Infinity);

            for (int i = 0; i < raycastHitArray.Length; i++)
            {
                if (raycastHitArray[i].collider.GetComponent<T>() != null && raycastHitArray[i].collider)
                {
                    normal = raycastHitArray[i].normal;
                }
            }

            return normal;
        }

        public static Vector3 GetRaycastPlanePoint(Vector3 fingerPosition, Vector3 inNormal, Vector3 inPosition, Camera camera)
        {
            Ray ray = new Ray();
            Plane plane = new Plane(inNormal, inPosition);
            Vector3 hitPoint = Vector3.zero;

            ray = camera.ScreenPointToRay(fingerPosition);

            bool didHit = plane.Raycast(ray, out float distance);

            if (didHit)
            {
                hitPoint = ray.GetPoint(distance);
            }

            return hitPoint;
        }

        #endregion Functions
    }
}