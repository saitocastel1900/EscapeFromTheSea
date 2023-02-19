using UnityEngine;
using UnityEngine.UI;

namespace Score
{
    public class TimerView : MonoBehaviour
    {
        /// <summary>
        /// タイマーのText
        /// </summary>
        [SerializeField] private Text _text;
        
        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialize()
        {
            _text.text = "";
        }

        /// <summary>
        /// 時間を更新
        /// </summary>
        public void UpdateText(float text)
        {
            var value = Mathf.Floor(text);
            _text.text = value.ToString();
        }
    }
}