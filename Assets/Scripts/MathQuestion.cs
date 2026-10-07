using TMPro;
using Unity.Multiplayer.Center.Common;
using UnityEngine;

public class MathQuestion : MonoBehaviour
{
    public GameData gameData;
    public TMP_Text text;
    public TMP_InputField inputField;
    public int answer;
    public bool IsAnswered = false;


    void Start()
    {
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
        if (inputField.text == answer.ToString())
        {
            IsAnswered = true;

            //Destroy(gameObject);
            this.gameObject.SetActive(false);
        }
    }
}
