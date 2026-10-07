using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScriptVer2 : MonoBehaviour
{
    public GameObject questionPrefab;
    //public GameObject numbad;
    //public GameObject numb;
    public GameObject question;
    public Canvas canvas;
    public List<GameObject> listOfQuestions = new List<GameObject>();

    [SerializeField]
    public float enemySpeed;


    //////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////
    void Start()
    {
        //numb = Instantiate(numbad, transform.position, Quaternion.identity);
        //numb.transform.position = gameObject.transform.position;
        //numb.transform.SetParent(canvas.transform, false);
        int num = UnityEngine.Random.Range(1, 4);
        for (int i = 0; i < num; i++)
        {
            question = Instantiate(questionPrefab, transform.position, Quaternion.identity);
            question.transform.position = gameObject.transform.position;
            question.transform.SetParent(canvas.transform, false);
            listOfQuestions.Add(question);
        }
    }

    void Update()
    {
        moveEnemy();
        checkList();
    }
    //////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////


    void moveEnemy()
    {
        Vector2 newPosition = transform.position;
        newPosition.x -= enemySpeed * Time.deltaTime;
        transform.position = newPosition;
    }

    void checkList()
    {
        if (listOfQuestions.Count == 0)
            Destroy(this.gameObject);
        /*
        foreach(GameObject question in listOfQuestions)
        {
            MathQuestion mathQuestion = question.GetComponent<MathQuestion>();
            if (mathQuestion.IsAnswered == true)
            {
                listOfQuestions.Remove(question);
            }
        }*/
        bool first = true;

        for (int i = 0; i < listOfQuestions.Count; i++)
        {
            MathQuestionVer2 mathQuestion = listOfQuestions[i].GetComponent<MathQuestionVer2>();
            if (first)
            {
                mathQuestion.inputField.ActivateInputField();
                first = false;
            }
            if (mathQuestion.IsAnswered == true)
            {
                listOfQuestions.Remove(listOfQuestions[i]);
                break;
            }
        }
    }
}
