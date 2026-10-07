using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject levelSelect;
    public GameObject menu;
    public void PlayGame()
    {
        levelSelect.SetActive(true);
        menu.SetActive(false);
    }

    public void QuitGame()
    {
        // Debug.Log("Quit!");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
