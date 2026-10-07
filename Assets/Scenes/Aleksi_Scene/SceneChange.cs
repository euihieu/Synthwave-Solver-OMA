using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    Scene thisScene;
    public bool restart = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thisScene = SceneManager.GetActiveScene();
    }

    public void ChangeScene()
    {
        if (restart)
            SceneManager.LoadScene(thisScene.name);
        else
            SceneManager.LoadScene(0);
    }

    // Update is called once per fram
}
