using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
    public TimerManager timerManager;
    public FightManager fightManager;
    public TextMeshProUGUI clock;
    private void Update()
    {
        // add string before clock.text
        clock.text = "00:0" + Mathf.Ceil(timerManager.timeRemaining).ToString();
    }

    void visibility()
    {
        if (fightManager.isFighting == true)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
