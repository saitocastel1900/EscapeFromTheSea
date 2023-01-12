using System.Reflection;
using UnityEngine;

namespace Commons.Utility
{
    /// <summary>
    /// 将来的に#ifとかで分岐するのを予想して、
    /// Debugをラップ
    /// </summary>
    public static class DebugUtility
    {
       /// <summary>
       /// エラーログ
       /// </summary>
       /// <param name="type">使用しているシステムをここに</param>
       /// <param name="message">プログラムのどこで、何をしたのかをここに</param>
       /// <param name="obj">使用しているクラスをここに</param>
       /// <param name="method">呼ばれた場所のメソッドをここに</param>
        public static void LogError(string type,string message,object obj=null,MethodBase method=null)
        {
#if UNITY_EDITOR
            Debug.LogError($"【{type}】{message}：{obj.GetType().Name}.{method.Name}");
#endif
        }

       /// <summary>
       /// デバッグログ
       /// </summary>
       /// <param name="type">使用しているシステムをここに</param>
       /// <param name="message">プログラムのどこで、何をしたのかをここに</param>
       /// <param name="obj">使用しているクラスをここに</param>
       /// <param name="method">呼ばれた場所のメソッドをここに</param>
       public static void Log(string type,string message,object obj=null,MethodBase method=null)
        {
#if UNITY_EDITOR
            Debug.Log($"【{type}】{message}：{obj.GetType().Name}.{method.Name}");
#endif
        }
    }
}