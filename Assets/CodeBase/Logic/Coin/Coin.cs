using System;
using CodeBase.Logic.Generic;
using CodeBase.StaticData.Strings;
using UnityEngine;

namespace CodeBase.Logic.Coin
{
    public class Coin : MonoBehaviour
    {
        [SerializeField]
        private TriggerObserver _triggerObserver;

        [SerializeField]
        private CoinDeath _coinDeath;

        public Action<Coin> OnCollected;
    
        private bool _isCollected;

        private void OnEnable() => 
            _triggerObserver.OnTriggerEntered += TryCollectCoin;
    
        private void OnDisable() => 
            _triggerObserver.OnTriggerEntered -= TryCollectCoin;

        private void TryCollectCoin(Collider collider)
        {
            if (_isCollected)
                return;
        
            if (!collider.CompareTag(TagsNames.Player))
                return;

            CollectCoin();
        }

        private void CollectCoin()
        {
            _isCollected = true;
            OnCollected?.Invoke(this);
        
            _coinDeath.Die();
        }
    }
}
