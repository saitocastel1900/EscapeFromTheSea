namespace Commons
{
    /// <summary>
    /// Intの拡張メソッド
    /// </summary>
    public static class IntExtensions
    {
        /// <summary>
        /// 値を加算し、範囲を超えたら0からの値として返す
        /// </summary>
        public static int Repeat(this int self, int value, int max)
        {
            return (self + value + max) % max;
        }
    }
}