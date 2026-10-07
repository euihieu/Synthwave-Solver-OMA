using System.Collections;
using UnityEngine;
using UnityEngine.Splines;

public class Obsticle : MonoBehaviour
{
    public float lifeTime;
    [SerializeField] private float moveSpeed = 0.01f;
    private float multiplier;
    public bool isMoving;
    public Vector3 newPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lifeTime = 20;
        Debug.Log(this.name);
        isMoving = false;
        newPosition = transform.position;
        newPosition.y += 0.1f;
        multiplier = 1;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Physics2D.IgnoreCollision(collision.transform.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
    private void StartMovement()
    {
        isMoving = true;

        float step = moveSpeed;
        transform.position = Vector3.MoveTowards(transform.position, newPosition, step);

        if (Vector3.Distance(transform.position, newPosition) < 0.01f)
        {
            multiplier *= -1;
            newPosition.y += multiplier * 0.2f;
            Debug.Log(multiplier + " " + newPosition);
        }

        isMoving = false;
    }
    public void  KillSwitch(float time)
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
            Destroy(this.gameObject);
        lifeTime = time;
    }
    // Update is called once per frame
    void Update()
    {
        if (this.name.Contains("Bird"))
            StartMovement();
        KillSwitch(lifeTime);
    }
}
