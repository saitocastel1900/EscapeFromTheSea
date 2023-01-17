using System.Reflection;
using Commons.Utility;
using UnityEngine;
using UnityEngine.Serialization;

namespace RipCurrent
{
    public class RipCurrentView : MonoBehaviour
    {
        [SerializeField, Header("波の範囲")]
        private Vector3 _generalPosRange; 
        [SerializeField, Header("離岸流の範囲")]
        private Vector3 _ripCurrentPosRange; 
        
        [SerializeField] private BoxCollider _generalCollider;
        [SerializeField] private BoxCollider _ripCurrentCollider;

        public void Initialized()
        {
            _generalCollider.size = new Vector3(Mathf.Abs(_generalPosRange.x),Mathf.Abs(_generalPosRange.y),Mathf.Abs(_generalPosRange.z));
            _ripCurrentCollider.size = new Vector3(Mathf.Abs(_ripCurrentPosRange.x),Mathf.Abs(_ripCurrentPosRange.y),Mathf.Abs(_ripCurrentPosRange.z));
            DebugUtility.Log("離岸流","当たり判定のサイズを設定",this,MethodBase.GetCurrentMethod());
        }

        //TODO:矢印を描画出来るようにする
        /// <summary>
        /// 波の押し出し判定を描画
        /// </summary>
        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0,1f,0,0.5f);
            Gizmos.DrawWireCube(transform.localPosition,_generalPosRange);
            Gizmos.DrawCube(transform.localPosition,_generalPosRange*2);
            
            Gizmos.color = new Color(1f,0,0,0.5f);
            Gizmos.DrawWireCube(transform.localPosition,_ripCurrentPosRange);
            Gizmos.DrawCube(transform.localPosition,_ripCurrentPosRange*2);
        }
    }
}