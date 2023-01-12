using UnityEngine.UI;
using DG.Tweening;
using UnityEngine;

namespace Commons.Utility
{
    public static class AnimationUtility
    {
        /// <summary>
        /// ボタンの表示前のScale
        /// </summary>
        private static readonly Vector3 ButtonBeforeShowScale = new Vector3(0.7f, 0.7f, 0.7f);

        /// <summary>
        /// FadeInのTween
        /// </summary>
        public static Tween FadeInTween(Graphic graphic, float duration = 0.3f)
        {
            return graphic.DOFade(1f, duration);
        }

        /// <summary>
        /// FadeInのTween
        /// </summary>
        public static Tween FadeInTween(CanvasGroup canvasGroup, float duration = 0.3f)
        {
            return canvasGroup.DOFade(1f, duration);
        }

        /// <summary>
        /// FadeOutのTween
        /// </summary>
        public static Tween FadeOutTween(Graphic graphic, float duration = 0.5f)
        {
            return graphic.DOFade(0f, duration);
        }

        /// <summary>
        /// FadeOutのTween
        /// </summary>
        public static Tween FadeOutTween(CanvasGroup canvasGroup, float duration = 0.5f)
        {
            return canvasGroup.DOFade(0f, duration);
        }

        /// <summary>
        /// ボタン表示の準備を行う
        /// </summary>
        public static void ReadyShowButton(Transform buttonTransform, CanvasGroup buttonCanvasGroup)
        {
            buttonTransform.localScale = ButtonBeforeShowScale;
            buttonCanvasGroup.alpha = 0f;
        }

        /// <summary>
        /// ボタン表示のTween
        /// </summary>
        public static Tween ShowButtonTween(Transform buttonTransform, CanvasGroup buttonCanvasGroup)
        {
            var sequence = DOTween.Sequence();
            sequence.Insert(0f, buttonTransform.DOScale(1.1f, 0.3f).SetEase(Ease.OutCirc));
            sequence.Insert(0.5f, buttonTransform.DOScale(1f, 0.1f).SetEase(Ease.OutCirc));
            sequence.Insert(0f, FadeInTween(buttonCanvasGroup));
            return sequence;
        }

        /// <summary>
        /// ボタン非表示のTween
        /// </summary>
        public static Tween HideButtonTween(CanvasGroup buttonCanvasGroup)
        {
            return FadeOutTween(buttonCanvasGroup);
        }
    }
}