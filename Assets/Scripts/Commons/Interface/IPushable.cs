using System;
using UnityEngine;

namespace Commons.Interface
{
    public interface IPushable
    {
        /// <summary>
        /// 押す
        /// </summary>
        public void Push(Action OnCallBack=null);
    }
}