using UnityEngine;

namespace CodeBase.Logic.Coin
{
    public class CoinDeath : MonoBehaviour
    {
        [SerializeField]
        private GameObject _deathEffect;

        public void Die()
        {
            Instantiate(_deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
       
    }
}
