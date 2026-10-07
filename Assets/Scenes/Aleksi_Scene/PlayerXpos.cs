using UnityEngine;

public class PlayerXpos : MonoBehaviour
{
    public GameObject player;
    float x;
    float y;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void UpdatePosition()
    {
        x = player.transform.position.x;
        y = transform.position.y;
        transform.position = new Vector2(x, y);

    }
    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
    }
}
