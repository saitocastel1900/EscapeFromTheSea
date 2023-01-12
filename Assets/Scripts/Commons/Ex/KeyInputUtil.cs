using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace InputAsRx.Util{
    internal static class KeyInputUtil{
        internal enum InputType{
            GetKey, GetKeyDown, GetKeyUp, anyKey, anyKeyDown
        }

        private static readonly Dictionary<InputType, Func<KeyCode, bool>> inputTable = new Dictionary<InputType, Func<KeyCode, bool>>{
            {InputType.GetKey, UnityEngine.Input.GetKey},
            {InputType.GetKeyDown, UnityEngine.Input.GetKeyDown},
        };

        internal static IObservable<Unit> CreateSubject(InputType inputType, KeyCode keyCode = KeyCode.None) =>
            Observable.EveryUpdate()
                .Where(_ => inputTable[inputType](keyCode))
                .AsUnitObservable();
    }
}
