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

        public void Initialize()
        {
            SetSlide(0);
        }

        public IObservable<Unit> OnClickNextButton()
        {
            return _nextButton.OnClickAsObservable();
        }
        
        public IObservable<Unit> OnClickBackButton()
        {
            return _backButton.OnClickAsObservable();
        }

        public void SetSlide(int slideNum)
        {
            _slideImage.sprite = _slideSprites[slideNum];
        }
    }
}