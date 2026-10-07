using System.Linq;
using UnityEngine;

public class Calculator : MonoBehaviour
{
    public string buttonPressed;
    public string answer;
    void Start()
    {

    }

    void FormulateAnswer()
    {
        if (buttonPressed != null && buttonPressed != "BACK")
        {
            answer += buttonPressed;
            Debug.Log(answer);
        }
        if (buttonPressed == "BACK" && answer != null)
        {
            answer = answer.Remove(answer.Length - 1);
        }


        buttonPressed = null;
    }
    void Update()
    {
        FormulateAnswer();
    }
}
