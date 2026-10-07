using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameUI : MonoBehaviour
{
    public Image MyImage;
    public Player playerScript;
    public PlayerHealthNew playerHealthNewScript;
    public TimeManagerNew timeManager;
    public GameObject endGameWrapper;

    //UnityEvent<string> gameEnd;
    private bool gameOver = false;

    public TMP_Text gameOverText;

    private void Awake()
    {
        MyImage.color += new Color(MyImage.color.r, MyImage.color.g, MyImage.color.b, 0);
    }

    private void Start()
    {
        /* if (gameEnd == null)
             gameEnd = new UnityEvent<string>();

         gameEnd.AddListener(EndGame);*/
        timeManager.endGame.AddListener(EndGame);
        playerHealthNewScript.endGame.AddListener(EndGame);

    }
    void EndGame(string endHow)
    {
        //playerHealthNewScript.OnDeath?.Invoke(playerHealthNewScript.isDead);
        //timeManager
        if (!gameOver)
        {
            string saveText = endHow; //fix for engame text changing after game ended
            gameOver = true;
            SoundManager.instance.GameEnd("fail");
            playerScript.OnDisable();
            playerScript.moveSpeed = 0;
            updateText(endHow);
            StartCoroutine(DoFade());
            endGameWrapper.SetActive(true);
        }

    }
    public IEnumerator DoFade()
    {
        while (MyImage.color.a < 0.9)
        {
            MyImage.color += new Color(MyImage.color.r, MyImage.color.g, MyImage.color.b, (Time.deltaTime / 2));
            yield return null;

        }
        yield return null;
    }
    private void updateText(string text)
    {
        if (playerHealthNewScript.currentHealth > 0)
            gameOverText.text = text;
        else
            gameOverText.text = text;
    }
}
