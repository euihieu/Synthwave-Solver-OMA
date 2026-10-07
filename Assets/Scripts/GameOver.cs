using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public Player playerScript;
    public PlayerHealthNew playerHealthNewScript;

    public TextMeshProUGUI text;

    private void Start()
    {
        playerHealthNewScript.OnDeath?.Invoke(playerHealthNewScript.isDead);
        playerScript.input.Disable();
        updateText();
    }

    private void updateText()
    {
        text.text = "Game Over";
    }
}
