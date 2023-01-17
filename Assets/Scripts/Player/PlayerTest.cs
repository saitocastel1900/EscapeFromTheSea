using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Cursor = UnityEngine.Cursor;

public class PlayerTest : MonoBehaviour
{
    private Animator _animator;
    private Quaternion targetRotation;
    public Button _buttonBool;
    public Button _buttonTrriger;
    
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        TryGetComponent(out _animator);
        targetRotation = transform.rotation;
        _buttonBool.onClick.AddListener(()=>_animator.SetBool("IsGround",!_animator.GetBool("IsGround")));
        _buttonTrriger.onClick.AddListener(()=>_animator.SetTrigger("IsDie"));
        
    }

    private void Update()
    {
        //カメラの向きでの制した入力ベクトルの取得
        var horizontal = UnityEngine.Input.GetAxis("Horizontal");
        var vertical = UnityEngine.Input.GetAxis("Vertical");
        var horizontalRotation = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up);
        var velocity =horizontalRotation * new Vector3(horizontal, 0, vertical).normalized;
        
        //速度の取得
        var speed = UnityEngine.Input.GetKey(KeyCode.LeftShift) ? 2 : 1;
        var rotationSpeed = 600 * Time.deltaTime;
        
        //移動方向を向く
        if (velocity.magnitude > 0.5f)
        {
            targetRotation = Quaternion.LookRotation(velocity, Vector3.up);
        }
        
        _animator.SetFloat("Speed",velocity.magnitude*speed,0.1f,Time.deltaTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation,rotationSpeed);
    }
}