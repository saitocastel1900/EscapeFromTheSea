using UniRx;
using UnityEngine;
using System;
using Commons.Const;

namespace Player
{
    public class PlayerModel
    {
        /// <summary>
        /// 体力が0になった時に呼ばれる
        /// </summary>
        public event Action OnHpOverBack;
        
        /// <summary>
        /// 体力
        /// </summary>
        public IReactiveProperty<int> HpProp => _hpProp;

        private IntReactiveProperty _hpProp;
        private int HP => _hpProp.Value;

        /// <summary>
        /// 位置座標
        /// </summary>
        public Vector3 Pos => _pos;
        private Vector3 _pos;

        /// <summary>
        /// 回転角度
        /// </summary>
        public Quaternion Rotation => _rotation;
        private Quaternion _rotation;
        private Quaternion _targetRotation;
        
        /// <summary>
        /// 進行方向
        /// </summary>
        private Vector3 _direction;
        
        /// <summary>
        /// 歩くスピード
        /// </summary>
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
        
        /// <summary>
        /// プレイヤーの位置と回転角度を計算
        /// </summary>
        public void UpdateMove(int speed, Vector3 direction)
        {
            //カメラの正面方向を基準とした、必要な回転量を取得
            var cameraDirection = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up);

            UpdateSpeed(speed);
            UpdateDirection(direction, cameraDirection);

            UpdateRotation();
            UpdatePos();
        }

        /// <summary>
        /// 位置を更新
        /// </summary>
        private void UpdatePos()
        {
            CalcPos();
        }

        /// <summary>
        /// 位置を計算
        /// </summary>
        private void CalcPos()
        {
            _pos = _direction * _speed;
        }

        /// <summary>
        /// 回転角度を更新
        /// </summary>
        private void UpdateRotation()
        {
            CalcRotation();
        }

        /// <summary>
        /// 回転角度を計算
        /// </summary>
        private void CalcRotation()
        {
            //移動方向を向く
            if (_direction.magnitude > 0.5f)
            {
                _targetRotation = Quaternion.LookRotation(_direction, Vector3.up);
            }

            _rotation = _targetRotation;
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateSpeed(int speed)
        {
            _speed = speed;
        }

        /// <summary>
        /// 移動方向を更新
        /// </summary>
        private void UpdateDirection(Vector3 direction, Quaternion cameraDirection)
        {
            _direction = cameraDirection * direction;
        }

        /// <summary>
        /// 体力を更新
        /// </summary>
        public void UpdateHp()
        {
            _hpProp.Value = Mathf.Clamp(HP + InGameConst.Damage, 0, 10);

            //体力が限界値を超えたらコールバックを起動
            if (_hpProp.Value>=InGameConst.MaxHp)
            {
                OnHpOverBack?.Invoke();
            }
        }
    }
}