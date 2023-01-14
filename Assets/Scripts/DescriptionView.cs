using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Description
{
    public class DescriptionView : MonoBehaviour
    {
        [SerializeField] private List<Sprite> _slideSprites;
        [SerializeField] private Image _slideImage;

        [SerializeField] private Button _nextButton;
        [SerializeField] private Button _backButton;

        /// <summary>
        /// 
        /// </summary>
        public void Initialize()
        {
            SetSlide(0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IObservable<Unit> OnClickNextButton()
        {
            return _nextButton.OnClickAsObservable();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IObservable<Unit> OnClickBackButton()
        {
            return _backButton.OnClickAsObservable();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="slideNum"></param>
        public void SetSlide(int slideNum)
        {
            _slideImage.sprite = _slideSprites[slideNum];
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void Show()
        {
            this.gameObject.SetActive(true);
        }
         
        /// <summary>
        /// 
        /// </summary>
        public void Hide()
        {
            this.gameObject.SetActive(false);
        }
    }
}