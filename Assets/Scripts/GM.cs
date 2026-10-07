using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    public GameObject player;
    public float playerSpeed;
    public GameObject calculatorVisibility;
    public GameObject questionVisibility;
           Player playerPlayer;
    public float oldSpeed;
    public GameObject enemy;
    public Animator anim;
    public KillEnemy killEnemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerPlayer = player.GetComponent<Player>();
        playerSpeed = playerPlayer.moveSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            oldSpeed = playerPlayer.moveSpeed;
            enemy = collision.gameObject;
            killEnemy = enemy.GetComponent<KillEnemy>();
            FightManager2.instance.fight();
            playerPlayer.moveSpeed = 0;
            calculatorVisibility.SetActive(true);
            questionVisibility.SetActive(true);
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (!FightManager2.instance.isFighting && FightManager2.instance.hasFought)
        {
            calculatorVisibility.SetActive(false);
            questionVisibility.SetActive(false);
            //playerPlayer.moveSpeed = oldSpeed;
            if (killEnemy.isDying == false)
                killEnemy.Kill();
        }
        //Debug.Log(playerSpeed);
    }
}
