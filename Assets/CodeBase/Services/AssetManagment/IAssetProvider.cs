using UnityEngine;

namespace CodeBase.Services.AssetManagment
{
    public interface IAssetProvider
    {
        GameObject Instantiate(string path, Transform at, Transform parent = null);
        GameObject Instantiate(string path, GameObject at, Transform parent = null);
        GameObject Instantiate(string path, Vector3 at);
        GameObject Instantiate(string path);
    }
}
