using UnityEngine;

public class ObsManagerUP : MonoBehaviour
{
    public GameObject obstaclePrefab;


    void Start()
    {
        InvokeRepeating("obstaclePrefab", 0f, 2f);
    }
}
