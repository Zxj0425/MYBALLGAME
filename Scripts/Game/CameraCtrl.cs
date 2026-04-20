using System;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    private Vector3 _vector3;
    private PlayerCtrl _playerCtrl;
    private void Awake()
    {
        _playerCtrl = GameManager.FindObjectOfType<PlayerCtrl>();
        _vector3 = transform.position - _playerCtrl.transform.position;
    }
    
    
    //因为相机跟随必须要在Update里面的逻辑执行完了才可以移动(不然相机会抖动)
    private void LateUpdate()
    {
        transform.position = _vector3 + _playerCtrl.transform.position;
    }
}
