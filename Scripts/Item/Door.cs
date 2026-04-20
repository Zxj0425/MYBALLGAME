using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //当前关卡胜利
            GameManager.Instance.GameWin();
        }
    }
}
