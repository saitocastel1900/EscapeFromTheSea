using System.Reflection;
using Commons.Utility;
using UnityEngine;

namespace RipCurrent
{
    public class RipCurrentView : MonoBehaviour
    {
        [SerializeField, Header("オブジェクトを生成したい場所の範囲(矩形)")]
        private Vector3 objectPosRange; //オブジェクトの生成範囲

        [SerializeField] private BoxCollider _collider;
        
        public void Initialized()
        {
            _collider.size = new Vector3(Mathf.Abs(objectPosRange.x),Mathf.Abs(objectPosRange.y),Mathf.Abs(objectPosRange.z));
            DebugUtility.Log("離岸流","当たり判定のサイズを設定",this,MethodBase.GetCurrentMethod());
        }

        //TODO:矢印を描画出来るようにする
        /// <summary>
        /// 波の押し出し判定を描画
        /// </summary>
        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0,1f,0,0.5f);
            Gizmos.DrawWireCube(transform.localPosition,objectPosRange);
            Gizmos.DrawCube(transform.localPosition,objectPosRange);
        }
    }
}