using UnityEngine;

namespace CodeBase.Services.Unity
{
    public class CoroutineRunner : MonoBehaviour, ICoroutineRunner
    {
        private void OnEnable()
        {
            DontDestroyOnLoad(this);
        }

    }
}
