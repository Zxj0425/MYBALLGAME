using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHelper : MonoBehaviour
{
    private PlayerCtrl _playerCtrl;
    private void Start()
    {
        _playerCtrl = GameManager.FindObjectOfType<PlayerCtrl>();
    }

    private void Update()
    {
        transform.position = _playerCtrl.transform.position;
    }
}
