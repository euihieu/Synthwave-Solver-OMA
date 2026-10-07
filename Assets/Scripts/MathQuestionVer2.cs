using TMPro;
using Unity.Multiplayer.Center.Common;
using UnityEngine;

public class MathQuestionVer2 : MonoBehaviour
{
    public GameData gameData;
    public TMP_Text text;
    public TMP_InputField inputField;
    public int answer;
    public Calculator calculator;
    public bool IsAnswered = false;



    void Start()
    {
        calculator = FindAnyObjectByType<Calculator>();
        QuestionMaker();
    }

    void QuestionMaker()
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

    void Update()
    {
        if (inputField.isFocused == true)
            inputField.text = calculator.answer;
        Debug.Log(calculator.answer);
        if (calculator.answer == answer.ToString())
        {
            calculator.answer = null;
            IsAnswered = true;

            //Destroy(gameObject);
            this.gameObject.SetActive(false);
        }
    }
}
