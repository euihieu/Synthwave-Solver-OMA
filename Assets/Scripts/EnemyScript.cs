using UnityEngine;
using System.Collections.Generic;

public class EnemyScript : MonoBehaviour
{
    public GameObject questionPrefab;
    public GameObject question;
    public Canvas canvas;
    public List<GameObject> listOfQuestions = new List<GameObject>();
    private float enemySpeed = 4f;
    private PlayerHealth playerHealth;
    private bool hasFought;
    private bool hasSpawnedQuestion;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        hasFought = false;
        hasSpawnedQuestion = false;
    }

    void Update()
    {
        moveEnemy();
        checkList();

        if (FightManager.instance.isFighting == true && !hasSpawnedQuestion)
        {
            spawnQuestion();
        }
        answerResultManagement();
    }

    void spawnQuestion()
    {
        int num = UnityEngine.Random.Range(1, 1);
        for (int i = 0; i < num; i++)
        {
            question = Instantiate(questionPrefab, transform.position, Quaternion.identity);
            question.transform.SetParent(canvas.transform, false);
            listOfQuestions.Add(question);
        }
        hasSpawnedQuestion = true;
    }

    void moveEnemy()
    {
        if (FightManager.instance.isFighting == true)
            return;

        transform.Translate(Vector2.left * enemySpeed * Time.deltaTime);

        if (transform.position.x <= 5 && !hasFought)
        {
            FightManager.instance.fight();
            hasFought = true;
        }
        else if (transform.position.x < -12)
        {
            Destroy(gameObject);
        }
    }

    void checkList()
    {
        bool first = true;

        for (int i = listOfQuestions.Count - 1; i >= 0; i--)
        {
            MathQuestion mathQuestion = listOfQuestions[i].GetComponent<MathQuestion>();

    	    if (first)
    		{

    		    mathQuestion.inputField.ActivateInputField();
                first = false;

                if (mathQuestion.IsAnswered)
                {
                    listOfQuestions.Remove(listOfQuestions[i]);
                    break;
                }
            }
        }
    }

    void answerResultManagement()
    {
        if (FightManager.instance.isFighting && listOfQuestions.Count == 0)
        {
            Destroy(gameObject);
            StreakManager.instance.increaseStreak();
            FightManager.instance.endFight();
        }
        else if (!FightManager.instance.isFighting && listOfQuestions.Count > 0 && hasFought)
        {
            foreach (GameObject q in listOfQuestions)
                Destroy(q);
            listOfQuestions.Clear();
            StreakManager.instance.resetStreak();
            PlayerHealth.instance.applyDamage(1);
        }
    }
}
