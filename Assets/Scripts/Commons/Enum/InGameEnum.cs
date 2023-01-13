namespace Commons.Enum
{
    public static class InGameEnum
    {
        /// <summary>
        /// 状態
        /// </summary>
        public enum State
        {
            None       = 0,
            WaitStart  = 1,      
            Fly        = 1 << 1, 
            Hit        = 1 << 2, 
            Falling    = 1 << 3, 
            Dead       = 1 << 4, 
        }
    }
}