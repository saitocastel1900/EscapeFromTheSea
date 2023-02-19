using System;
using System.Reflection;
using Commons.Utility;
using UniRx.Triggers;
using UnityEngine;

namespace RipCurrent
{
    public class RipCurrentView : MonoBehaviour
    {
        /// <summary>
        /// 波で押し返されるエリア
        /// </summary>
        [SerializeField] private BoxCollider _generalCollider;
        
        /// <summary>
        /// 離岸流で押し返されるエリア
        /// </summary>
        [SerializeField] private BoxCollider _ripCurrentCollider;

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialized()
        {
            _generalCollider.size = new Vector3(Mathf.Abs(_generalCollider.size.x),Mathf.Abs(_generalCollider.size.y),Mathf.Abs(_generalCollider.size.z));
            _ripCurrentCollider.size = new Vector3(Mathf.Abs(_ripCurrentCollider.size.x),Mathf.Abs(_ripCurrentCollider.size.y),Mathf.Abs(_ripCurrentCollider.size.z));
            DebugUtility.Log("離岸流","当たり判定のサイズを設定",this,MethodBase.GetCurrentMethod());
        }
        
        /// <summary>
        /// 波の押し出し判定を描画
        /// </summary>
        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0,1f,0,0.5f);
            Gizmos.DrawCube(transform.localPosition,new Vector3(_generalCollider.size.x*2,_generalCollider.size.y,_generalCollider.size.z*2));
            
            Gizmos.color = new Color(1f,0,0,0.5f);
            Gizmos.DrawCube(transform.localPosition,new Vector3(_ripCurrentCollider.size.x*2,_ripCurrentCollider.size.y,_ripCurrentCollider.size.z*2));
        }

        /// <summary>
        /// 当たり判定にいる間のObservableを返す
        /// </summary>
        public IObservable<Collider> OnTriggerEnterStay()
        {
            return _ripCurrentCollider.OnTriggerStayAsObservable();
        }
    }
}