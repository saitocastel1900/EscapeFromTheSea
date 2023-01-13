using TMPro;
using UnityEngine;

namespace Score
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        
        public void Initialize()
        {
            _text.text = "";
        }

        public void UpdateText(float text)
        {
            var value = Mathf.Floor(text);
            _text.text = value.ToString();
        }
    }
}