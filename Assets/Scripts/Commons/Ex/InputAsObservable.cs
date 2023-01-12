using System;
using InputAsRx.Util;
using UniRx;
using UnityEngine;

namespace InputAsRx{
    public static class InputAsObservable{
        public static IObservable<Unit> GetKey(KeyCode keyCode) =>
            KeyInputUtil.CreateSubject(KeyInputUtil.InputType.GetKey, keyCode);
        
        public static IObservable<Unit> GetKeyDown(KeyCode keyCode) =>
            KeyInputUtil.CreateSubject(KeyInputUtil.InputType.GetKeyDown, keyCode);
    }
}
