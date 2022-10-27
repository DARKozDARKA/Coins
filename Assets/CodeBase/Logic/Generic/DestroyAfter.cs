using UnityEngine;

namespace CodeBase.Logic.Generic
{
    public class DestroyAfter : MonoBehaviour
    {
        [SerializeField]
        private float _time;

        private void Start() => 
            Destroy(gameObject, _time);
    }
}
