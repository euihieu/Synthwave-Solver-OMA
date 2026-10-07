using UnityEngine;

public class ObsManagerDOWN : MonoBehaviour
{
    public GameObject obstaclePrefab;


    void Start()
    {
        InvokeRepeating("obstaclePrefab", 2f, 2f);
    }
}
