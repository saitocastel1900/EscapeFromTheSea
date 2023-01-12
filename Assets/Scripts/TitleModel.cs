using UniRx;
using UnityEngine;

namespace Title
{
    public class TitleModel : MonoBehaviour
    {
        private BoolReactiveProperty _isPushProp;
        public IReactiveProperty<bool> IsPushProp => _isPushProp;
        public bool IsPush => _isPushProp.Value;
        
        public void Initialized()
        {
            _isPushProp = new BoolReactiveProperty(false);
        }

        public void UpdatePush(bool isPush)
        {
            _isPushProp.Value = isPush;
        }
    }
}