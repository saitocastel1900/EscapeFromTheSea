using System;
using UnityEngine;

namespace Commons.Interface
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPushable
    {
        public void Push(Action OnCallBack);
    }
}