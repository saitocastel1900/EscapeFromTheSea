using Commons.Interface;

namespace InGame
{
    //BUG:クラス名のIngameDataは抽象的すぎるので、変更する
    
    /// <summary>
    /// 
    /// </summary>
    public class InGameData : IDataHolder
    { 
        private bool _isClear;

        /// <summary>
        /// 
        /// </summary>
        public InGameData(bool isClear=true)
        {
            _isClear = isClear;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isClear"></param>
        public void Set(bool isClear)
        {
            _isClear = isClear;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Get()
        {
            return _isClear;
        }
    }
}