using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Title
{
    /// <summary>
    /// 
    /// </summary>
    public class TitleView : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _exitButton;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IObservable<Unit> OnClickPlay()
        {
            return _playButton.OnClickAsObservable();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IObservable<Unit> OnClickExit()
        {
            return _exitButton.OnClickAsObservable();
        }
    }
}