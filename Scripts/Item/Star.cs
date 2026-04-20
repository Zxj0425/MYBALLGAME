using UnityEngine;

public class Star : MonoBehaviour
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
            //播放音效
            GameManager.Instance.PlayCoinClip();
            //添加得分
            GameManager.Instance.CurrStarCount++;
            //销毁自己
            Destroy(this.gameObject);
        }
    }
}