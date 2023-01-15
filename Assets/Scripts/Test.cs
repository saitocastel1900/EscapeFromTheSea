using Commons.Interface;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class Test : MonoBehaviour
{
    [SerializeField] private string _scene;

    [Inject]
    private IDataHolder _data;
    
    // Start is called before the first frame update
    void Start()
    {
        InputAsRx.InputAsObservable
            .GetKeyDown(KeyCode.Space)
            .Subscribe(_=>
            {
                _data.Set(true);
                Debug.Log(_data.Get());
                SceneManager.LoadScene(_scene);
            })
            .AddTo(this.gameObject);
    }
}
