using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class TimeManagerNew : MonoBehaviour
{
    public float timeRemaining = 7f;
    // public float bonusTime1 = 1f;
    // public float bonusTime2 = 2f;
    // public float bonusTime3 = 3f;

    // public float bonused1;
    // public float bonused2;
    // public float bonused3;

    public float bonusTime = 0f;
    public float finalTime;
    public bool countTime = false;
    public bool timesUp = false;
    public TMP_Text UItimer;

    public UnityEvent<string> endGame;



    private void Start()
    {
        if (endGame == null)
            endGame = new UnityEvent<string>();
        finalTime = bonusTime + timeRemaining;
    }

    private void Update()
    {
        if (timeRemaining > 0.00f && countTime)
        {
            timeRemaining -= Time.deltaTime;
        }
        else if (countTime)
        {
            timeRemaining = 0;
            timesUp = true;
            endGame?.Invoke("Time's Up");
            Debug.Log("Time's up!");
        }
    }
    
    public void stopTime()
    {
        UItimer.gameObject.SetActive(false);
        countTime = false;
        //finalTime = timeRemaining;
        timeRemaining = finalTime;
    }


    public void startTimer()
    {
        UItimer.gameObject.SetActive(true);
        timeRemaining = finalTime + bonusTime;
        countTime = true;
    }
}
