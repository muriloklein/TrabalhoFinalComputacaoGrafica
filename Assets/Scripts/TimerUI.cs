using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    void Update()
    {
        float time = GameManager.Instance.GetTimer();

        if (time < 0) time = 0;

        timerText.text = time.ToString("Timer: 00.0");
    }
}
