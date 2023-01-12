using System;
using Cysharp.Threading.Tasks;
using UnityEngine.UI;
using DG.Tweening;
using UniRx;
using UnityEngine;

namespace Commons.Utility
{
    public static class TitleAnimationUtility
    {
        public static Tween PanelFadeOutTween(Image panel)
        {
           return panel.DOFade(0f, 0.5f)
               .SetEase(Ease.Linear).OnComplete(() => { Debug.Log("フェードアウトが完了しました"); });
        }
        
        public static Tween TransitionEffectTween(Image panel,Subject<Unit> OnCallback)
        {
            return panel.DOFade(1.0f, 0.2f)
                .SetEase(Ease.Linear).OnComplete(() =>
                {
                    Debug.Log("フェードインが完了しました");
                    OnCallback.OnNext(Unit.Default);
                });
        }

        public static Tween FadeImageLoopTween(Image image)
        {
            return image.DOFade(0.0f, 1f)
                .SetEase(Ease.InCubic).SetLoops(-1, LoopType.Yoyo);
        }
    }
}