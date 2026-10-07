using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;

public class StreakManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI playerFeedback;
    public TMPro.TextMeshProUGUI streakFeedback;
    public TMPro.TextMeshProUGUI healthRewardFeedback;
    public TMPro.TextMeshProUGUI timeRewardFeedback;

    // private List<GameObject> streakReward;

    public static StreakManager instance { get; private set; }
    public int currentStreak { get; private set; }
    public PlayerHealth playerHealth;

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
        StartCoroutine(playerFeedbackCR());
    }

    IEnumerator streakFeedbackCR()
    {
        if (currentStreak == 2)
        {
            streakFeedback.text = $"Double C";
            streakFeedback.gameObject.SetActive(true);

            //add time to timer
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
            playerHealth.applyHeal(1);
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
            timeRewardFeedback.text = $"+1s";
            timeRewardFeedback.gameObject.SetActive(true);
        }
        else if (currentStreak == 7)
        {
            streakFeedback.text = $"Splendid!!";
            streakFeedback.gameObject.SetActive(true);

            //add health to player
            healthRewardFeedback.text = $"+1hp";
            healthRewardFeedback.gameObject.SetActive(true);
            Debug.Log("Healed player");
        }
        else if (currentStreak == 8)
        {
            streakFeedback.text = $"Magnificent!!!";
            streakFeedback.gameObject.SetActive(true);
            //add time to timer
            timeRewardFeedback.text = $"+1s";
            timeRewardFeedback.gameObject.SetActive(true);
        }
        else if (currentStreak == 9)
        {
            streakFeedback.text = $"Incredible!!!!";
            streakFeedback.gameObject.SetActive(true);

            //add health to player
            healthRewardFeedback.text = $"+1hp";
            healthRewardFeedback.gameObject.SetActive(true);
            Debug.Log("Healed player");
        }
        else if (currentStreak >= 10)
        {
            streakFeedback.text = $"Amazing!!!!!";
            streakFeedback.gameObject.SetActive(true);

            //add time to timer
            timeRewardFeedback.text = $"+1s";
            timeRewardFeedback.gameObject.SetActive(true);
            //add health to player
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
