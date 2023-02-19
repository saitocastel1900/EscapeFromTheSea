using Commons.Interface;

namespace InGame
{
    /// <summary>
    /// InGameのデータを管理するクラス
    /// </summary>
    public class InGameData : IDataHolder
    { 
        //ゲームをクリアしたかどうか
        private bool _isClear;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public InGameData(bool isClear=false)
        {
            _isClear = isClear;
        }

        /// <summary>
        /// クリアフラグを設定する
        /// </summary>
        public void Set(bool isClear)
        {
            _isClear = isClear;
        }

        /// <summary>
        /// クリアフラグを返す
        /// </summary>
        public bool Get()
        {
            return _isClear;
        }
    }
}