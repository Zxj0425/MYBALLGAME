using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Coin : MonoBehaviour
{
    public float speed;
    private void Update()
    {
        //自转
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.CurrCoinCount++;
            GameManager.Instance.PlayCoinClip();
            Destroy(this.gameObject);
        }
    }
}
