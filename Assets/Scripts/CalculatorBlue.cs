using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class CalculatorBlue : MonoBehaviour
{
    public string buttonPressed;
    public string answer;
    public TMP_Text text;
    InputAction myBackspace;
    public QuestionHandler questionHandler;
    public bool WasSubmitted = false;
    void Start()
    {
        myBackspace = InputSystem.actions.FindAction("BackButton");
    }

    void FormulateAnswer()
    {
        if (buttonPressed != null && buttonPressed != "OK")
        {
            answer += buttonPressed;
        }
        if (buttonPressed == "BACK" && answer != null)
        {
            answer = answer.Remove(answer.Length - 1);
        }
        if (buttonPressed == "OK" && answer != null && !WasSubmitted)
        {
            WasSubmitted = true;

        }
        if (myBackspace.triggered && answer != null)
        {
            answer = answer.Remove(answer.Length - 1);
        }
        text.text = answer;
        Debug.Log(buttonPressed);
        buttonPressed = null;
        /*if (buttonPressed == "OK")
        {
            StartCoroutine(Wait());
        }
        else
            buttonPressed = null;*/
    }
    /*public IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        buttonPressed = null;
    }*/
    void Update()
    {
        FormulateAnswer();
    }
}
