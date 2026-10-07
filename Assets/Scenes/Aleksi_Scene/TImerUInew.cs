using TMPro;
using UnityEngine;

public class TimerUInew : MonoBehaviour
{
    public TimeManagerNew timerManager;
    public TMP_Text clock;

    private void Start()
    {
        clock.color = Color.white;
    }
    private void Update()
    {
        // add string before clock.text
        if (timerManager.timeRemaining < 4)
            clock.color = Color.red;
        else
            clock.color = Color.white;
        if (timerManager.timeRemaining < 10)
            clock.text = "00:0" + Mathf.Ceil(timerManager.timeRemaining).ToString();
        else
            clock.text = "00:" + Mathf.Ceil(timerManager.timeRemaining).ToString();

    }

}
