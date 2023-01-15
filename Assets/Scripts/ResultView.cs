using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Result
{
    /// <summary>
    /// 
    /// </summary>
    public class ResultView : MonoBehaviour
    {
        [SerializeField] private Image _resultImage;
        
        [SerializeField] private Sprite _gameOverSprite;
        [SerializeField] private Sprite _gameClearSprite;

        [SerializeField] private Button _titleButton;
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _descriptionButton;
        [SerializeField] private Button _closeButton;
        
        /// <summary>
        /// 
        /// </summary>
        public void Initialize()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            
            SetResult(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IObservable<Unit> OnClickTitleButton()
        {
            return _titleButton.OnClickAsObservable();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IObservable<Unit> OnClickPlayButton()
        {
            return _playButton.OnClickAsObservable();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IObservable<Unit> OnClickDescriptionButton()
        {
            return _descriptionButton.OnClickAsObservable();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IObservable<Unit> OnClickCloseButton()
        {
            return _closeButton.OnClickAsObservable();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isClear"></param>
        public void SetResult(bool isClear)
        {
            _resultImage.sprite = isClear ? _gameClearSprite : _gameOverSprite;
        }
    }
}