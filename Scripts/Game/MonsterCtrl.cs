using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class MonsterCtrl : MonoBehaviour
{
    public float speed;
    
    public Transform startTrans;
    public Transform endTrans;
    private Transform _targetTrans;

    private void Start()
    {
        _targetTrans = startTrans;
    }

    private void Update()
    {
        //游戏结束怪物的行为应当全部停止
        // if (GameManager.Instance.GameIsComplete)
        //     return;
        //这么写节约性能开销
        if (Vector3.SqrMagnitude(transform.position - startTrans.position) <= 1f)
            _targetTrans = endTrans;
        //这么写节约性能开销
        if (Vector3.SqrMagnitude(transform.position - endTrans.position) <= 1f)
            _targetTrans = startTrans;
        //怪物移动
        transform.position = Vector3.MoveTowards(transform.position, _targetTrans.position, speed * Time.deltaTime);
        //设置怪物朝向
        transform.forward = _targetTrans.position - transform.position;
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //播放玩家死亡音效
            GameManager.Instance.PlayPlayerDieClip();
            //打开GameOverUI
            GameManager.Instance.GameOver();
        }
    }
}