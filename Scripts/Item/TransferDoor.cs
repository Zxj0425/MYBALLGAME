using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class TransferDoor : MonoBehaviour
{
    public Transform targetTrans;
    private float _resetTimer = 0f;
    private bool _isStart = false;

    private void Update()
    {
        if (_isStart)
        {
            _resetTimer -= Time.deltaTime;
            if (_resetTimer <= 0f)
            {
                _resetTimer = 8f;
                _isStart = false;
                transform.GetComponent<BoxCollider>().enabled = true;
                transform.GetChild(0).GetComponent<MeshRenderer>().materials[1].color = Color.yellow;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.PlayTransferClip();
            //设置目标传送点
            targetTrans.GetComponent<TransferDoor>().StartReset();
            //设置自身传送点
            StartReset();
            other.transform.position = targetTrans.transform.position;
        }
    }

    public void StartReset()
    {
        _isStart = true;
        _resetTimer = 8f;
        transform.GetComponent<BoxCollider>().enabled = false;
        transform.GetChild(0).GetComponent<MeshRenderer>().materials[1].color = Color.red;
    }
}
