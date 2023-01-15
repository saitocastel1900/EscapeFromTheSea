using UnityEngine;
using UnityEngine.UI;

namespace Score
{
    public class TimerView : MonoBehaviour
    {
        [SerializeField] private Text _text;
        
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