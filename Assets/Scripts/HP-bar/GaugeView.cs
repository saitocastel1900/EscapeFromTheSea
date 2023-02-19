using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Gauge
{
    public class GaugeView : MonoBehaviour
    {
        /// <summary>
        /// HpのカウンターText
        /// </summary>
        [SerializeField] private Text _text;

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialized()
        {
            UpdateText(0);
        }

        /// <summary>
        /// 文字の数値を加算
        /// </summary>
        /// <param name="value"></param>
        public void UpdateText(int value)
        {
            _text.text = (10-value).ToString() + "/10";
        }

        #region GaugeAnimaion

        /// <summary>
        /// 体力バーのImage
        /// </summary>
        [SerializeField] private Image _gaugeImage;
        
        /// <summary>
        /// 体力バーの充填率
        /// </summary>
        [SerializeField] private float _gaugeValue;

        /// <summary>
        /// 体力バーの充填率
        /// </summary>
        public float GaugeValue
        {
            get => _gaugeValue;
            set
            {
                _gaugeValue = Mathf.Clamp(value * 0.1f, 0.0f, 1.0f);
            }
        }
        
        /// <summary>
        /// アニメーションの継続期間
        /// </summary>
        [SerializeField] private float duration = 0.2f;
        
        private Tweener _tweener=null;
        
        /// <summary>
        /// 体力バーのアニメーション
        /// </summary>
        public void GaugeAnimation()
        {
            if (_tweener != null)
            {
                _tweener.Kill();
                _tweener = null;
            }

            //充填率を設定
            _tweener = _gaugeImage.DOFillAmount(GaugeValue, duration)
                .SetEase(Ease.OutCubic);
        }
        
        #endregion
    }
}