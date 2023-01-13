using UnityEngine;
using UnityEngine.UI;

namespace Result
{
    public class ResultView : MonoBehaviour
    {
        [SerializeField] private Image _resultImage;
        
        [SerializeField] private Sprite _gameOverSprite;
        [SerializeField] private Sprite _gameClearSprite;
        
        /// <summary>
        /// 
        /// </summary>
        public void Initialize()
        {
            SetResult(false);
        }

        public void SetResult(bool isClear)
        {
            _resultImage.sprite = isClear ? _gameClearSprite : _gameOverSprite;
        }
    }
}