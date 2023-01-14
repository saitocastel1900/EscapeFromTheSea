using Commons.Interface;
using Commons.Utility;
using InGame;
using UniRx;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;
using Zenject;

public class Test : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private AssetReference _scene;

    [Inject]
    private IDataHolder _data;
    
    // Start is called before the first frame update
    void Start()
    {
        _button.OnClickAsObservable()
            .Subscribe(_=>
            {
                _data.Set(true);
                Debug.Log(_data.Get());
                SceneTransition.LoadScene(_scene);
            })
            .AddTo(this.gameObject);
    }
}
