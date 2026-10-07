using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class QuestionMaker : MonoBehaviour
{
    public GameData gameData;
    public TMP_Text text;
    public TMP_InputField inputField;
    public int answer = 0;
    public CalculatorBlue calculator;
    public bool IsAnswered = false;
    public bool IsCorrect = false;
    public List<int> numbers = new List<int>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //calculatorBlue = GetComponent<CalculatorBlue>;
        //QuestionGenerator();
        UltimateQuestionGenerator();

    }
    public void UltimateQuestionGenerator()
    {
        int numberOfNumbers = UnityEngine.Random.Range(2, gameData.maxNumbers);
        int mathRand = UnityEngine.Random.Range(0, 10);
        while (numberOfNumbers > 0)
        {
            if (gameData.sign == '+' || gameData.sign == '-')
            {
                if (mathRand < 5)
                    gameData.sign = '-';
                else
                    gameData.sign = '+';
            }
            numberOfNumbers--;
            int number = UnityEngine.Random.Range(1, 9);
            if (gameData.sign == '+')
            {
                text.text += $"{number} ";
                if (numberOfNumbers > 0)
                    text.text += $"{gameData.sign} ";
                else
                    text.text += $"= ";
                answer += number;

            }
            if (gameData.sign == '-')
            {
                
                numbers.Add(number);

                if (numberOfNumbers == 0)
                {
                    answer = -1;
                    while (answer < 0)
                    {
                        text.text = null;
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            numbers[i] = UnityEngine.Random.Range(0, 12);
                            if (i == 0)
                            {
                                answer = numbers[i];
                                text.text += $"{numbers[i]} ";
                            }
                            else
                            {
                                text.text += $"{numbers[i]} ";
                                answer -= numbers[i];
                            }
                            if (i < numbers.Count - 1)
                                text.text += $"{gameData.sign} ";
                            else
                                text.text += $"= ";
                        }

                    }
                }
            }
           /* if (gameData.sign == '-')
            {
                bool firstRound = true;
                if (firstRound)
                {
                    number += 4;
                    firstRound = false;
                }
                if (number > answer && answer != 0)
                {
                    //number = answer - 1;
                    number = UnityEngine.Random.Range(-1, answer);
                }
                text.text += $"{number} ";
                if (numberOfNumbers > 0)
                    text.text += $"{gameData.sign} ";
                else
                    text.text += $"= ";
                if (answer == 0)
                    answer = number;
                else
                    answer -= number;
            }*/
            if (gameData.sign == '*')
            {
                text.text += $"{number} ";
                if (numberOfNumbers > 0)
                    text.text += $"{gameData.sign} ";
                else
                    text.text += $"= ";
                //if answer is empty we just add the first number for multiplying it would allways result to 0
                if (answer == 0)
                    answer += number;
                else
                    answer = number * answer;
            }
            if (gameData.sign == '/')
            {
                //if answer is empty we just add the first number for multiplying it would allways result to 0
                if (answer == 0)
                    answer += number;
                else
                    answer = number * answer;

                if (numberOfNumbers == 0)
                    text.text += $"{answer} / {number} = ";
            }
        }
    }
    void QuestionGenerator()
    {
        int firstNumber = UnityEngine.Random.Range(2, 6);
        int secondNumber = UnityEngine.Random.Range(2, 6);
        //this.inputField.ActivateInputField();

        if (gameData.sign == '+')
        {
            text.text = $"{firstNumber} {gameData.sign} {secondNumber} = ";
            answer = firstNumber + secondNumber;
        }
        else if (gameData.sign == '-')
        {
            text.text = $"{firstNumber} {gameData.sign} {secondNumber} = ";
            answer = firstNumber - secondNumber;
        }
        else if (gameData.sign == '*')
        {
            text.text = $"{firstNumber} {gameData.sign} {secondNumber} = ";
            answer = firstNumber * secondNumber;
        }


    }
    public void CheckAnswer()
    {   if (calculator.WasSubmitted)
        {
            calculator.WasSubmitted = false;
            int parsedInt = int.Parse(calculator.answer);

            if (calculator.answer == answer.ToString())
            {
                IsCorrect = true;
                IsAnswered = true;
                ///inputField.image.color = Color.green;
            }
            else if (answer % parsedInt == 0)
            {
                IsCorrect = true;
                IsAnswered = true;
            }
            else
            {
                IsCorrect = false;
                IsAnswered = true;
            }
            calculator.answer = null;
            StartCoroutine(Wait());
        }
    }
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        //this.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (inputField.isFocused == true)
            inputField.text = calculator.answer;
        if (calculator.WasSubmitted)
        {
            Debug.Log("what");
            ////calculator.WasSubmitted = false;
            //CheckAnswer();
        }
        /*if (calculator.answer == answer.ToString())
        {
            calculator.answer = null;
            IsAnswered = true;
            //Destroy(gameObject);
            //this.gameObject.SetActive(false);
            inputField.image.color = Color.green;
        }*/

        /*if (calculator.WasSubmitted)
        {
            Debug.Log(calculator.answer + " " + answer.ToString());
            Debug.Log("HERE");
            if (calculator.answer == answer.ToString())
            {
                IsCorrect = true;
                //this.inputField.image.color = Color.green;
            }
            else
            {
                IsCorrect = false;
                //this.inputField.image.color = Color.red;
            }
            IsAnswered = true;
            calculator.answer = null;
            calculator.WasSubmitted = false;
            //calculator.buttonPressed = null;
        }*/
    }
}
