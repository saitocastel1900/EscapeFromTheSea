using UnityEngine;

namespace Manager
{
    //TODO:音を鳴らすメソッドを追加する
    //TODO:DIで実装する
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _source;
        [SerializeField] private AudioClip _clip;

        public void PlaySE()
        {
            _source.PlayOneShot(_clip);
        }
    }
}