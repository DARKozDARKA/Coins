using System;
using UnityEngine;

namespace CodeBase.Logic.Generic
{
    [RequireComponent(typeof(Collider))]
    public class TriggerObserver : MonoBehaviour
    {
        public event Action<Collider> OnTriggerEntered;
        public event Action<Collider> OnTriggerExited;

        private void OnTriggerEnter(Collider other) => 
            OnTriggerEntered?.Invoke(other);

        private void OnTriggerExit(Collider other) => 
            OnTriggerExited?.Invoke(other);
    }
}