using System;
using UnityEngine;

namespace Commons.Interface
{
    public interface IPushable
    {
        public void Push(Action OnCallBack);
    }
}