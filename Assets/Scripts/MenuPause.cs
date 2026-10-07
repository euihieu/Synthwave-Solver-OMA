using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{

    [SerializeField] GameObject menuPause;
    
    public void Pause()
    {
        menuPause.SetActive(true);
        Time.timeScale = 0;

    }

    public void Home()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
    }

    public void Resume()
    {
        menuPause.SetActive(false);
        Time.timeScale = 1;

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
