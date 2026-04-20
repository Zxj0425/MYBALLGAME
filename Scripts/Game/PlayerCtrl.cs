using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(SphereCollider))]
public class PlayerCtrl : MonoBehaviour
{
    public float speed;
    public float jump;
    
    private Rigidbody _rigidbody;
    
    private bool _isRoad = false;
    private bool _isJump = false;


    private float _hor;
    private float _ver;
    private Vector3 _dir;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        _hor = Input.GetAxis("Horizontal");
        _ver = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_isJump)
            {
                return;
            }
            _isJump = true;
        }
        
        //使用射线检测判断player是否在地面上（防止多次跳跃）
        if (Physics.Raycast(this.transform.position, Vector3.down, 0.6f, 1 << LayerMask.NameToLayer("Road")))
        {
            _isRoad = true;
        }

        //如果物理逻辑放在update中，可以正确运行，但是会有意想不到的bug
    }

    //物理逻辑
    private void FixedUpdate()
    {
        //跳跃
        if (_isJump && _isRoad)
        {
            _isJump = false;
            _isRoad = false;
            _rigidbody.AddForce(0f, jump * Time.fixedDeltaTime, 0f, ForceMode.Impulse);
        }

        //移动
        //Approximately 近似某个值
        if (Mathf.Approximately(_hor, 0f) && Mathf.Approximately(_ver, 0f))
            return;
        
        _dir = new Vector3(_hor, 0f, _ver);
        //normalized 归一化,只有方向没有大小
        _rigidbody.AddForce(_dir.normalized * Time.fixedDeltaTime * speed);
    }
}