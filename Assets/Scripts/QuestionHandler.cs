using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionHandler : MonoBehaviour
{
    public GameObject questionPrefab;
    public GameObject question;
    public GameObject panel;
    public List<GameObject> listOfQuestions = new List<GameObject>();
    public CalculatorBlue calculator;
    public CalculatorBlue component;
    public bool hasSpawnedQuestion;
    public List<GameObject> listToPreserve = new List<GameObject>();
    [SerializeField]
    public GM gameManager;

    void Start()
    {
        /*
        int num = UnityEngine.Random.Range(1, 4);
        for (int i = 0; i < num; i++)
        {
            question = Instantiate(questionPrefab, transform.position, Quaternion.identity);
            question.GetComponent<QuestionMaker>().calculator = calculator;
            question.transform.position = gameObject.transform.position;
            question.transform.SetParent(panel.transform, false);
            listOfQuestions.Add(question);
        }*/
        hasSpawnedQuestion = false;
    }
    public void SpawnQuestion()
    {
        int num = UnityEngine.Random.Range(1, 4);
        for (int i = 0; i < num; i++)
        {
            question = Instantiate(questionPrefab, transform.position, Quaternion.identity);
            question.GetComponent<QuestionMaker>().calculator = calculator;
            question.transform.position = gameObject.transform.position;
            question.transform.SetParent(panel.transform, false);
            listOfQuestions.Add(question);
        }
        hasSpawnedQuestion = true;
    }
    public void checkList()
    {
        if (listOfQuestions.Count == 0 && PlayerHealthNew.instance.currentHealth != 0)
        {
            FightManager2.instance.EndFight();
            //this.gameObject.SetActive(false);
            //Destroy(this.gameObject);
        }

        bool first = true;

        for (int i = 0; i < listOfQuestions.Count; i++)
        {
            QuestionMaker mathQuestion = listOfQuestions[i].GetComponent<QuestionMaker>();
            if (first)
            {
                mathQuestion.inputField.ActivateInputField();
                first = false;
                mathQuestion.CheckAnswer();
            }
            if (mathQuestion.IsAnswered == true)
            {
                if (mathQuestion.IsCorrect == true)
                {
                    mathQuestion.inputField.image.color = Color.green;
                    StreakManagerNew.instance.increaseStreak();
                    SoundManager.instance.PlaySound("correct");

                }
                if (!mathQuestion.IsCorrect)
                {
                    mathQuestion.inputField.image.color = Color.red;
                    SoundManager.instance.PlaySound("wrong");
                    StreakManagerNew.instance.resetStreak();
                    PlayerHealthNew.instance.applyDamage(1);
                    gameManager.killEnemy.Attack();


                }
                listToPreserve.Add(listOfQuestions[i]);
                listOfQuestions.Remove(listOfQuestions[i]);
                break;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (FightManager2.instance.isFighting == true && !hasSpawnedQuestion)
        {
            SpawnQuestion();
        }
        checkList();
    }
}
