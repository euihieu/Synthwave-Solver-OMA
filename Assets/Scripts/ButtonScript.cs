using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public GameData gameData;
    public int level;
    public char sign;
    public int maxAmountOfNumbers;
    public void sceneChanger()
    {
        gameData.sign = sign;
        gameData.maxNumbers = maxAmountOfNumbers;
        SceneManager.LoadScene(level);
    }
}
