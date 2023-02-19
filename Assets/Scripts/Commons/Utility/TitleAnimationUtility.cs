using UnityEngine.UI;
using DG.Tweening;
using UniRx;
using UnityEngine;

namespace Commons.Utility
{
    public static class TitleAnimationUtility
    {
        /// <summary>
        /// パネルFadeOutのtween
        /// </summary>
        public static Tween PanelFadeOutTween(Image panel)
        {
           return panel.DOFade(0f, 0.5f)
               .SetEase(Ease.Linear).OnComplete(() => { Debug.Log("フェードアウトが完了しました"); });
        }
        
        /// <summary>
        /// シーン遷移演出のTween
        /// </summary>
        public static Tween TransitionEffectTween(Image panel,Subject<Unit> OnCallback)
        {
            return panel.DOFade(1.0f, 0.2f)
                .SetEase(Ease.Linear).OnComplete(() =>
                {
                    Debug.Log("フェードインが完了しました");
                    OnCallback.OnNext(Unit.Default);
                });
        }

        /// <summary>
        /// FadeLoopのTween
        /// </summary>
        public static Tween FadeImageLoopTween(Image image)
        {
            return image.DOFade(0.0f, 1f)
                .SetEase(Ease.InCubic).SetLoops(-1, LoopType.Yoyo);
        }
    }
}