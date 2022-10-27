using UnityEngine;

namespace CodeBase.StaticData.ScriptableObjects
{
    [CreateAssetMenu(fileName = "GameData", menuName = "StaticData/GameData")]
    public class GameData : ScriptableObject
    {
        public int PlayTime;

        private void OnValidate()
        {
            if (PlayTime <= 0)
            {
                Debug.LogError("Play time must be above 0");
                PlayTime = 1;
            }
               
        }
    }
}