using UnityEngine;
using System.Collections;

public class FightManager : MonoBehaviour
{
    // private float timer = 3f;
    private Coroutine fightCoroutine;
    public TimerManager timerManager;
    // public TimerUI timerUI;

    public bool isFighting { get; private set; }
    public static FightManager instance { get; private set; }
    public PlayerController playerController;

    ////////////////////////////////////////////////////////////////
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        isFighting = false;
    }
    ////////////////////////////////////////////////////////////////



    public void fight()
    {
        // if (!isFighting)
        // {
            isFighting = true;
            // fightCoroutine =
            playerController.inputActionAsset.FindActionMap("Player").Disable();

            StartCoroutine(fightTimeCR());

            Debug.Log("Fight started");

        // }
    }

    public IEnumerator fightTimeCR()
    {
        Debug.Log("Fight timer started");

        timerManager.startTimer();

        yield return new WaitForSeconds(timerManager.timeRemaining);
        isFighting = false;
        timerManager.startTimer();
        // fightCoroutine = null;
        Debug.Log("Fight ended");
    }

    public void endFight()
    {
        // if (fightCoroutine != null)
        // {
        StopCoroutine(fightTimeCR());
            // fightCoroutine = null;
        playerController.inputActionAsset.FindActionMap("Player").Enable();
        // }
        isFighting = false;
        timerManager.startTimer();
    }
}
