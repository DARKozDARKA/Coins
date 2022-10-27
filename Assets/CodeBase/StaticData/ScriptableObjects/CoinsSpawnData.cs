using UnityEngine;

namespace CodeBase.StaticData.ScriptableObjects
{
    [CreateAssetMenu(fileName = "CoinsSpawnData", menuName = "StaticData/CoinsSpawnData")]
    public class CoinsSpawnData : ScriptableObject
    {
        public float CoinsSpace;
        public float CoinsScatter;
    }
}