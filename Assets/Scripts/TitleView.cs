using System;
using InputAsRx;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Title
{
    public class TitleView : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _exitButton;
        
        public void Initialized()
        {
            
        }

        public IObservable<Unit> OnClickPlay()
        {
            return _playButton.OnClickAsObservable();
        }
        
        public IObservable<Unit> OnClickExit()
        {
            return _exitButton.OnClickAsObservable();
        }
    }
}