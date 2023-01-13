using Commons.Const;
using Input;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerView : MonoBehaviour
    {
        [Inject] private IInputMoveProvider _input;
        private Animator _animator;
        private float _rotationSpeed;

        public void Initialized()
        {
            TryGetComponent(out _animator);
            _rotationSpeed = 0;
        }

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

        public void ManualUpdate(Vector3 velocity, Quaternion targetRotation, float deltaTime)
        {
            SetPos(velocity, deltaTime);
            SetRotation(targetRotation, deltaTime);
        }

        private void SetRotation(Quaternion targetRotation, float deltaTime)
        {
            _rotationSpeed = InGameConst.RotationSpeed * deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed);
        }

        private void SetPos(Vector3 velocity, float deltaTime)
        {
            _animator.SetFloat("Speed", velocity.magnitude, 0.1f, deltaTime);
        }
    }
}