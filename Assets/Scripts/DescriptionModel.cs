using UniRx;
using UnityEngine;
using Commons.Const;

namespace Description
{
    public class DescriptionModel : MonoBehaviour
    {
        /// <summary>
        /// 
        /// </summary>
        public IReactiveProperty<int> SlideCurrentNumProp => _slideCurrentNumProp;
        public int SlideCurrentNum => _slideCurrentNumProp.Value;
        private IntReactiveProperty _slideCurrentNumProp;

        /// <summary>
        /// 
        /// </summary>
        public void Initialize()
        {
            _slideCurrentNumProp = new IntReactiveProperty(DescriptionConst.InitializeSlideNum);
        }

        /// <summary>
        /// 
        /// </summary>
        public void AddSlideNum()
        {
            _slideCurrentNumProp.Value=CalcCurrentSlideNum(DescriptionConst.SlideAdditionNum);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void SubSlideNum()
        {
            _slideCurrentNumProp.Value=CalcCurrentSlideNum(DescriptionConst.SlideSubtractionNum);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private int CalcCurrentSlideNum(int value)
        {
           return Mathf.Clamp(SlideCurrentNum+value,DescriptionConst.SlideNumMin,DescriptionConst.SlideNumMax);
        }
    }
}