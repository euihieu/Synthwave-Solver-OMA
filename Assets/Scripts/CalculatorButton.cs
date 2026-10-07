using TMPro;
using UnityEngine;

public class CalculatorButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public CalculatorBlue calculator;
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
