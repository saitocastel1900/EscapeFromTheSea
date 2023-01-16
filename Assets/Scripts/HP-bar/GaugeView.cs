using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Gauge
{
    public class GaugeView : MonoBehaviour
    {
        [SerializeField] private Text _text;

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialized()
        {
           // UpdateText(0);
        }

        /// <summary>
        /// 文字の数値を加算
        /// </summary>
        /// <param name="value"></param>
        public void UpdateText(int value)
        {
            //BUG:ここは直す（データの計算を扱ってしまっているため）
            Debug.Log("テキスト数値："+value);
            _text.text = (10-value).ToString() + "/10";
        }

        #region GaugeAnimaion

        [SerializeField] private Image _gaugeImage;
        [SerializeField] private float _gaugeValue;

        public float GaugeValue
        {
            get => _gaugeValue;
            set
            {
                _gaugeValue = Mathf.Clamp(value * 0.1f, 0.0f, 1.0f);
            }
        }
        
        [SerializeField] private float duration = 0.2f;
        private Tweener _tweener=null;
        public void GaugeAnimation()
        {
            if (_tweener != null)
            {
                _tweener.Kill();
                _tweener = null;
            }

            _tweener = _gaugeImage.DOFillAmount(GaugeValue, duration)
                .OnComplete(() => Debug.Log("アニメーション修了"))
                .SetEase(Ease.OutCubic);
        }
        
        #endregion
    }
}