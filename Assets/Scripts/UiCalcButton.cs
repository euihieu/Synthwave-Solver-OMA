using TMPro;
using UnityEngine;

public class UiCalcButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Calculator calculator;
    public TMP_Text text;

    private void Start()
    {
        text = GetComponentInChildren<TMP_Text>();
    }
    public void ButtonPressed()
    {
        calculator.buttonPressed = text.text;
    }
}
