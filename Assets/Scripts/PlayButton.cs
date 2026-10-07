using UnityEngine;

public class PlayButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject levelSelect;
    public void Toggle()
    {
        levelSelect.SetActive(true);
        gameObject.SetActive(false);
    }
    private void Update()
    {
        if (!levelSelect)
            gameObject.SetActive(true);
    }
}
