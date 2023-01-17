using System;
using Commons.Const;
using Input;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace Player
{
    /// <summary>
    /// 
    /// </summary>
    public class PlayerView : MonoBehaviour
    {
        /// <summary>
        /// 
        /// </summary>
        [Inject] private IInputMoveProvider _input;
        
        /// <summary>
        /// 
        /// </summary>
        private Animator _animator;
        
        /// <summary>
        /// 
        /// </summary>
        private float _rotationSpeed;

        /// <summary>
        /// 
        /// </summary>
        public void Initialized()
        {
            TryGetComponent(out _animator);
            _rotationSpeed = 0;
        }

        public IObservable<ObservableStateMachineTrigger.OnStateInfo> OnStateExit()
        {
           return 
               _animator.GetBehaviour<ObservableStateMachineTrigger>().OnStateUpdateAsObservable();
        }

        /// <summary>
        /// 
        /// </summary>
        public Vector3 InputMove()
        {
            var vector = Vector3.zero;

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

            Debug.Log(vector.normalized);
            return vector.normalized;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public int InputSpeed()
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
        /// 
        /// </summary>
        public void ManualUpdate(Vector3 velocity, Quaternion targetRotation, float deltaTime)
        {
            SetPos(velocity, deltaTime);
            SetRotation(targetRotation, deltaTime);
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetRotation(Quaternion targetRotation, float deltaTime)
        {
            _rotationSpeed = InGameConst.RotationSpeed * deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed);
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetPos(Vector3 velocity, float deltaTime)
        {
            _animator.SetFloat("Speed", velocity.magnitude, 0.1f, deltaTime);
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetWalk()
        {
            if(!_animator.GetBool("IsGround"))_animator.SetBool("IsGround", true);
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetSwim()
        {
            if(_animator.GetBool("IsGround"))_animator.SetBool("IsGround", false);
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetDie()
        {
             _animator.SetTrigger("IsDie");
        }
    }
}