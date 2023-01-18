using UniRx;
using UnityEngine;
using System;

namespace Player
{
    /// <summary>
    ///
    /// </summary>
    public class PlayerModel
    {
        /// <summary>
        /// 
        /// </summary>
        public event Action OnHpOverBack;
        
        /// <summary>
        /// 
        /// </summary>
        public IReactiveProperty<int> HpProp => _hpProp;

        private IntReactiveProperty _hpProp;
        private int HP => _hpProp.Value;

        public Vector3 Pos => _pos;
        private Vector3 _pos;

        public Quaternion Rotation => _rotation;
        private Quaternion _rotation;

        private Quaternion _targetRotation;
        private Vector3 _direction;
        private int _speed;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PlayerModel(Transform transform)
        {
            _hpProp = new IntReactiveProperty(0);
            
            _rotation = Quaternion.identity;
            _targetRotation = transform.rotation;
            
             _pos =Vector3.zero;
            _direction = Vector3.zero;
            _speed = 0;
        }

        public void ManualUpdate(int speed, Vector3 direction)
        {
            UpdateMove(speed, direction);
        }
        
        private void UpdateMove(int speed, Vector3 direction)
        {
            var cameraDirection = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up);

            UpdateSpeed(speed);
            UpdateDirection(direction, cameraDirection);

            UpdateRotation();
            UpdatePos();
        }

        private void UpdatePos()
        {
            CalcPos();
        }

        private void CalcPos()
        {
            _pos = _direction * _speed;
        }

        private void UpdateRotation()
        {
            CalcRotation();
        }

        private void CalcRotation()
        {
            //移動方向を向く
            if (_direction.magnitude > 0.5f)
            {
                _targetRotation = Quaternion.LookRotation(_direction, Vector3.up);
            }

            _rotation = _targetRotation;
        }

        private void UpdateSpeed(int speed)
        {
            _speed = speed;
        }

        private void UpdateDirection(Vector3 direction, Quaternion cameraDirection)
        {
            _direction = cameraDirection * direction;
        }

        public void UpdateHp()
        {
            var value = HP + 1;
            Debug.Log("Modelの値" + value);
            _hpProp.Value = Mathf.Clamp(value, 0, 10);

            if (_hpProp.Value>=10)
            {
                OnHpOverBack?.Invoke();
            }
        }
    }
}