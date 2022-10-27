using UnityEngine;

namespace CodeBase.Services.AssetManagment
{

    public class AssetProvider : IAssetProvider
    {
        public GameObject Instantiate(string path, Transform at, Transform parent = null)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, at.position, Quaternion.identity, parent);
        }

        public GameObject Instantiate(string path, GameObject at, Transform parent = null)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, at.transform.position, Quaternion.identity, parent);
        }
        public GameObject Instantiate(string path, Vector3 at)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, at, Quaternion.identity);
        }
        public GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, Vector3.zero, Quaternion.identity);
        }
    }
}