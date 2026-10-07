using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject obstacle1;
    public GameObject obstacle2;
    public GameObject obstacle3;
    public GameObject enemyPrefab;
    public GameObject airSpawn;
    public GameObject groundSpawn;
    public GameObject trackEnemy = null;
    bool hasSpawned = true;
    bool isSpawning = false;
    public float gapTime;
    int numberOfSpawns;

    private void Start()
    {
        gapTime = 2f;
    }
    void SpawnObstacles()
    {
        numberOfSpawns = UnityEngine.Random.Range(3, 7);
        hasSpawned = true;
        StartCoroutine(SpawnThrottle(gapTime));

    }
    public IEnumerator SpawnThrottle(float time)
    {
        for (int i = 0; i < numberOfSpawns; i++)
        {
            int objNro = UnityEngine.Random.Range(0, 4);
            time = UnityEngine.Random.Range(0.75f, 1f);
            if(objNro == 1)
                Instantiate(obstacle1, groundSpawn.transform.position, Quaternion.identity);
            else if (objNro == 2)
                Instantiate(obstacle2, airSpawn.transform.position, Quaternion.identity);
            else
                Instantiate(obstacle3, groundSpawn.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(time);

        }
        yield return new WaitForSeconds(gapTime);
        isSpawning = false;
    }
    void SpawnEnemy()
    {
        trackEnemy = Instantiate(enemyPrefab, gameObject.transform.position, Quaternion.identity);
    }
    private void Update()
    {
        if (!trackEnemy && !isSpawning)
        {
            SpawnEnemy();
            hasSpawned = false;
            isSpawning = true; //hack
        }
        if (!trackEnemy && !hasSpawned)
            SpawnObstacles();
    }
}
