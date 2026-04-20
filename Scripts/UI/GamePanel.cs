using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour
{
    public Text starText;
    public Text timeText;
    public Text coinText;

    public void SetStarText(int count)
    {
        starText.text = $"stars:{count}";
    }

    public void SetTimeText(float time)
    {
        timeText.text = $"Game time:{time}";
    }

    public void SetCoinText(int count)
    {
        coinText.text = $"gold coins:{count}";
    }
}