using System;
using Commons.Const;
using Input;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerView : MonoBehaviour
    {
        /// <summary>
        /// 入力装置
        /// </summary>
        [Inject] private IInputMoveProvider _input;
        
        /// <summary>
        /// プレイヤーのAnimator
        /// </summary>
        private Animator _animator;
        
        /// <summary>
        /// プレイヤーの回転スピード
        /// </summary>
        private float _rotationSpeed;

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialized()
        {
            TryGetComponent(out _animator);
            _rotationSpeed = 0;
        }

        /// <summary>
        /// アニメーションのObservableステートを返す
        /// </summary>
        public IObservable<ObservableStateMachineTrigger.OnStateInfo> OnStateExit()
        {
           return _animator.GetBehaviour<ObservableStateMachineTrigger>().OnStateUpdateAsObservable();
        }

        /// <summary>
        /// 進行方向を返す
        /// </summary>
        public Vector3 GetDirection()
        {
            var vector = Vector3.zero;

            //入力がキーに対応した方向を返す
            if (_input.InputAhead() || _input.InputBack() || _input.InputLeft() || _input.InputRight())
            {
                if (_input.InputAhead())
                    vector += Vector3.forward;
                if (_input.InputBack())
                    vector += Vector3.back;
                if (_input.InputLeft())
                    vector += Vector3.left;
                if (_input.InputRight())
                    vector += Vector3.right;
            }
            
            return vector.normalized;
        }
        
        /// <summary>
        /// 歩行スピードを設定
        /// </summary>
        public int SetSpeed()
        {
            if (_input.InputSpeedUp())
            {
                return InGameConst.EnhancementSpeed;
            }
            else
            {
                return InGameConst.NormalSpeed;
            }
        }

        /// <summary>
        /// 手動Update
        /// </summary>
        public void ManualUpdate(Vector3 velocity, Quaternion targetRotation, float deltaTime)
        {
            SetPos(velocity, deltaTime);
            SetRotation(targetRotation, deltaTime);
        }

        /// <summary>
        /// 回転角度を設定
        /// </summary>
        private void SetRotation(Quaternion targetRotation, float deltaTime)
        {
            _rotationSpeed = InGameConst.RotationSpeed * deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed);
        }

        /// <summary>
        /// 位置を設定
        /// </summary>
        private void SetPos(Vector3 velocity, float deltaTime)
        {
            _animator.SetFloat("Speed", velocity.magnitude, 0.1f, deltaTime);
        }

        /// <summary>
        /// プレイヤーのアニメーションを歩行モーションに設定する
        /// </summary>
        public void SetWalk()
        {
            if(!_animator.GetBool("IsGround"))_animator.SetBool("IsGround", true);
        }

        /// <summary>
        /// プレイヤーのアニメーションを水泳モーションに設定する
        /// </summary>
        public void SetSwim()
        {
            if(_animator.GetBool("IsGround"))_animator.SetBool("IsGround", false);
        }

        /// <summary>
        /// プレイヤーのアニメーションを死亡モーションに設定する
        /// </summary>
        public void SetDie()
        {
             _animator.SetTrigger("IsDie");
        }
    }
}