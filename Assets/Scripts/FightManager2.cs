using UnityEngine;
using System.Collections;

public class FightManager2 : MonoBehaviour
{
    private float timer = 10f;
    private Coroutine fightCoroutine;
    public TimeManagerNew timeManager;

    public bool isFighting { get; private set; }
    public static FightManager2 instance { get; private set; }
    public PlayerController playerController;
    public Player player;
    public QuestionHandler questionHandler;
    public bool hasFought;

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
        if (!isFighting && fightCoroutine == null)
        {
            hasFought = false;
            isFighting = true;
            fightCoroutine = StartCoroutine(fightTimeCR());
            Debug.Log("Fight started");
            //playerController.inputActionAsset.FindActionMap("Player").Disable();
            player.OnDisable();
        }
    }

    public IEnumerator fightTimeCR()
    {
        Debug.Log("Fight timer started");
        timeManager.startTimer();
        yield return new WaitForSeconds(timeManager.timeRemaining);
        //if (timeManager.timesUp)
        //{
        //    questionHandler.checkList();
        //}
        isFighting = false;
        fightCoroutine = null;
        Debug.Log("Fight ended");
    }

    public void EndFight()
    {
        if (fightCoroutine != null)
        {

            StopCoroutine(fightCoroutine);
            if (isFighting && questionHandler.listOfQuestions.Count == 0)
            {
                hasFought = true;
                questionHandler.hasSpawnedQuestion = false;
                timeManager.stopTime();
                player.input.Enable();
                player.moveSpeed = 12;
                foreach (GameObject q in questionHandler.listToPreserve)
                    Destroy(q);
                questionHandler.listToPreserve.Clear();
            }
            fightCoroutine = null;
            //playerController.inputActionAsset.FindActionMap("Player").Enable();
        }
        isFighting = false;
    }
}
