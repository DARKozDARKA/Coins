using TMPro;
using UnityEngine;

namespace CodeBase.UI
{
    public class TMPTextChanger : TextChanger
    {
        [SerializeField]
        private TextMeshProUGUI _text;
    
        public override void ChangeText(string text) => 
            _text.text = text;
    }
}