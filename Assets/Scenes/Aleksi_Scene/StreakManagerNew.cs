using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreakManagerNew : MonoBehaviour
{
    public TMPro.TextMeshProUGUI playerFeedback;
    public TMPro.TextMeshProUGUI streakFeedback;
    public TMPro.TextMeshProUGUI healthRewardFeedback;
    public TMPro.TextMeshProUGUI timeRewardFeedback;

    // private List<GameObject> streakReward;

    public static StreakManagerNew instance { get; private set; }
    public int currentStreak { get; private set; }
    //public PlayerHealthNew playerHealth;
    public TimeManagerNew timeManager;

    //////////////////////////////////////////////////////////////////////
    void Awake()
    {
        instance = this;
    }
    //////////////////////////////////////////////////////////////////////

    public void increaseStreak()
    {
        currentStreak++;
        StartCoroutine(streakFeedbackCR());
    }

    public void resetStreak()
    {
        currentStreak = 0;
        timeManager.bonusTime = 0f;
        StartCoroutine(playerFeedbackCR());
    }

    IEnumerator streakFeedbackCR()
    {
        if (currentStreak == 2)
        {
            streakFeedback.text = $"Double C";
            streakFeedback.gameObject.SetActive(true);

            //add time to timer
            //timeManager.timeRemaining += 1f;
            timeManager.bonusTime += 1f;
            timeRewardFeedback.text = $"+1s";
            timeRewardFeedback.gameObject.SetActive(true);
        }
        else if (currentStreak == 3)
        {
            streakFeedback.text = $"Triple C";
            streakFeedback.gameObject.SetActive(true);

        }
        else if (currentStreak == 4)
        {
            streakFeedback.text = $"Quad C";
            streakFeedback.gameObject.SetActive(true);

            //add time to timer
            //add health to player
            PlayerHealthNew.instance.applyHeal(1);
            healthRewardFeedback.text = $"+1hp";
            healthRewardFeedback.gameObject.SetActive(true);
            Debug.Log("Healed player");
        }
        else if (currentStreak == 5)
        {
            streakFeedback.text = $"Quintuple C";
            streakFeedback.gameObject.SetActive(true);

        }
        else if (currentStreak == 6)
        {
            streakFeedback.text = $"Excellent!";
            streakFeedback.gameObject.SetActive(true);

            //add time to timer
            timeManager.bonusTime += 1f;
            timeRewardFeedback.text = $"+1s";
            timeRewardFeedback.gameObject.SetActive(true);
        }
        else if (currentStreak == 7)
        {
            streakFeedback.text = $"Splendid!!";
            streakFeedback.gameObject.SetActive(true);

            //add health to player
            PlayerHealthNew.instance.applyHeal(1);
            healthRewardFeedback.text = $"+1hp";
            healthRewardFeedback.gameObject.SetActive(true);
            Debug.Log("Healed player");
        }
        else if (currentStreak == 8)
        {
            streakFeedback.text = $"Magnificent!!!";
            streakFeedback.gameObject.SetActive(true);
            //add time to timer
            timeManager.bonusTime += 1f;
            timeRewardFeedback.text = $"+1s";
            timeRewardFeedback.gameObject.SetActive(true);
        }
        else if (currentStreak == 9)
        {
            streakFeedback.text = $"Incredible!!!!";
            streakFeedback.gameObject.SetActive(true);

            //add health to player
            PlayerHealthNew.instance.applyHeal(1);
            healthRewardFeedback.text = $"+1hp";
            healthRewardFeedback.gameObject.SetActive(true);
            Debug.Log("Healed player");
        }
        else if (currentStreak >= 10)
        {
            streakFeedback.text = $"Amazing!!!!!";
            streakFeedback.gameObject.SetActive(true);

            //add time to timer
            timeManager.bonusTime += 1f;
            timeRewardFeedback.text = $"+1s";
            timeRewardFeedback.gameObject.SetActive(true);
            //add health to player
            PlayerHealthNew.instance.applyHeal(1);
            healthRewardFeedback.text = $"+1hp";
            healthRewardFeedback.gameObject.SetActive(true);
            Debug.Log("Healed player");
        }

        yield return new WaitForSeconds(1f);
        healthRewardFeedback.gameObject.SetActive(false);
        timeRewardFeedback.gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        streakFeedback.gameObject.SetActive(false);
    }

    IEnumerator playerFeedbackCR()
    {
        playerFeedback.text = $"uPsIs";
        playerFeedback.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        playerFeedback.gameObject.SetActive(false);
    }
}
