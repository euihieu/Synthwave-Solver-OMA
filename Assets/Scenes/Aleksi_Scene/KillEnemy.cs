using System.Collections;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    public Animator anim;
    public bool isDead = false;
    public bool isDying = false;
    public Rigidbody2D rb;
    public QuestionMaker questionMaker;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
    }

    public void Kill()
    {
        isDying = true;
        anim.Play("EnemyDeath");
        StartCoroutine(DeathTime(0.6f));
    }

    public IEnumerator DeathTime(float time)
    {
        yield return new WaitForSeconds(time);
        isDead = true;
    }
    public void Attack()
    {
        anim.Play("Attack");
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            Destroy(this.gameObject);
        }
    }
}
