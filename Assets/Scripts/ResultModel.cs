using UniRx;
using UnityEngine;
using Commons.Const;

namespace Result
{
    public class ResultModel : MonoBehaviour
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
            _slideCurrentNumProp = new IntReactiveProperty(ResultConst.InitializeSlideNum);
        }

        /// <summary>
        /// 
        /// </summary>
        public void AddSlideNum()
        {
            _slideCurrentNumProp.Value=CalcCurrentSlideNum(ResultConst.SlideAdditionNum);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void SubSlideNum()
        {
            _slideCurrentNumProp.Value=CalcCurrentSlideNum(ResultConst.SlideSubtractionNum);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private int CalcCurrentSlideNum(int value)
        {
           return Mathf.Clamp(SlideCurrentNum+value,ResultConst.SlideNumMin,ResultConst.SlideNumMax);
        }
    }
}