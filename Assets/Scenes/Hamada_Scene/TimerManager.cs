using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public float timeRemaining = 5f;

    public float bonusTime = 1f;
    public float finalTime;

    public FightManager fightManager;


    private void Update()
    {
        startTimer();
        resetTimer();
    }

    public void startTimer()
    {
        if (timeRemaining > 0 && fightManager.isFighting == true)
        {

            timeRemaining -= Time.deltaTime;
        }
        else
        {
            timeRemaining = 0;
            Debug.Log("Time's up!");
        }
    }

    public void resetTimer()
    {
        if (fightManager.isFighting == false)
        {

            finalTime = bonusTime + timeRemaining;
            timeRemaining = finalTime;
        }
    }
}
