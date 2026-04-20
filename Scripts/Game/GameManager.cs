using System;
using UnityEngine;
using UnityEngine.SceneManagement;

//虽然是单例但是和实际游戏中的单例不符合,这里这么使用是为了便于你理解
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    //定义游戏的字段 
    private int _currStarCount = 0;//当前获得的星星数量
    public int CurrStarCount
    {
        get => _currStarCount;
        set
        {
            _currStarCount = value;
            gamePanel.SetStarText(_currStarCount);
        }
    }//提供外界访问
    private const float GameOverTime = 240;//游戏结束时间
    private float _currGameSurplusTime = 0;//当前游戏剩余时间 (字段)
    public float CurrGameSurplusTime
    {
        get => _currGameSurplusTime;
        set
        {
            _currGameSurplusTime = value;
            gamePanel.SetTimeText(_currGameSurplusTime);
        }
    } 
    public bool GameIsComplete { get; private set; }//(属性)
    private int _currCoinCount = 0;
    public int CurrCoinCount
    {
        get => _currCoinCount;
        set
        {
            _currCoinCount = value;
            gamePanel.SetCoinText(_currCoinCount);
        }
    }
    
    //UI字段
    public GamePanel gamePanel;
    public GameWinPanel gameWinPanel;
    public GameOverPanel gameOverPanel;

    public AudioSource bgmAudioSource;
    public AudioSource otherAudioSource;
    public AudioClip bgmClip;
    public AudioClip playerDieClip;
    public AudioClip coinClip;
    public AudioClip transferClip;
    
    
    private void Awake()
    {
        //CurrGameSurplusTime++;
        
        //(无论到哪里都可以访问)
        Instance = this;
        //正常的单例全局唯一，且不销毁(如下)
        //DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        //对全局变量进行初始化
        CurrStarCount = 0;
        CurrCoinCount = 0;
        _currGameSurplusTime = GameOverTime;
        GameIsComplete = false;
        PlayBgm();
    }
    private void Update()
    {

        if (GameIsComplete)
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
        
        CurrGameSurplusTime -= Time.deltaTime;//时间减少
        if (CurrGameSurplusTime <= 0f)
        {
            //时间到了游戏结束（失败）
            GameOver();
        }
    }
    //UI相关
    public void GameWin()
    {

        GameIsComplete = true;
        gameWinPanel.gameObject.SetActive(true);
        gameWinPanel.SetUI(CurrStarCount);
    }
    public void GameOver()
    {
        GameIsComplete = true;
        gameOverPanel.gameObject.SetActive(true);
    }
    //播放声音

    public void PlayBgm()
    {
        bgmAudioSource.loop = true;
        bgmAudioSource.clip = bgmClip;
        bgmAudioSource.Play();
    }
    
    public void PlayPlayerDieClip()
    {
        otherAudioSource.loop = false;
        otherAudioSource.clip = playerDieClip;
        otherAudioSource.Play();
    }
    public void PlayCoinClip()
    {
        otherAudioSource.loop = false;
        otherAudioSource.clip = coinClip;
        otherAudioSource.Play();
    }
    public void PlayTransferClip()
    {
        otherAudioSource.loop = false;
        otherAudioSource.clip = transferClip;
        otherAudioSource.Play();
    }
}
