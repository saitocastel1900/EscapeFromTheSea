using UniRx;

namespace Commons.Enum
{
    /*
    public enum STEP
    {
        /// <summary>
        /// 変化待ち状態
        /// </summary>
        NONE = -1,

        /// <summary>
        /// 値の初期化時・準備
        /// </summary>
        SET,

        /// <summary>
        /// ゲームプレイ時
        /// </summary>
        PLAY,

        /// <summary>
        /// ゲーム終了時
        /// </summary>
        CLEAR,
    }*/

    [System.Serializable]
    public class EnumReactiveProperty : ReactiveProperty<InGameEnum.State>
    {
        //コンストラクタ
        public EnumReactiveProperty()
        {
        }

        public EnumReactiveProperty(InGameEnum.State initialValue) : base(initialValue)
        {
        }
    }
}