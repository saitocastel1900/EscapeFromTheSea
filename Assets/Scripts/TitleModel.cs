using UniRx;
using UnityEngine;

namespace Title
{
    /// <summary>
    /// 
    /// </summary>
    public class TitleModel : MonoBehaviour
    {
        /// <summary>
        /// 
        /// </summary>
        public IReactiveProperty<bool> IsPushProp => _isPushProp;
        public bool IsPush => _isPushProp.Value;
        private BoolReactiveProperty _isPushProp;
        
        /// <summary>
        /// 
        /// </summary>
        public void Initialized()
        {
            _isPushProp = new BoolReactiveProperty(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isPush"></param>
        public void GamePlay(bool isPush)
        {
            _isPushProp.Value = isPush;
        }
    }
}