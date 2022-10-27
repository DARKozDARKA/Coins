using UnityEngine;

namespace CodeBase.Logic.Generic
{
    public class ObjectRotator : MonoBehaviour
    {
        [SerializeField]
        private float _rotationSpeed;

        [SerializeField]
        private Vector3 _rotationVector;

        private void Update() => 
            transform.Rotate(_rotationVector.normalized * (_rotationSpeed * Time.deltaTime));
    }
}
