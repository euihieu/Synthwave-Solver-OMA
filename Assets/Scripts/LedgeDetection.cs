using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LedgeDetection : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Player player;

    private bool canDetect;

    // private BoxCollider2D boxCd; => GetComponent<BoxCollider2D>();

    void Update()
    {
        if (canDetect)
            player.ledgeDetected = Physics2D.OverlapCircle(transform.position, radius, whatIsGround);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            canDetect = false;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        // Collider2D[] colliders = Physics2D.OverlapBoxAll(boxCd.bounds.center, boxCd.size, 0);

        // foreach (var hit in colliders)
        // {
        //     if (hit.gameObject.GetComponent<PlatformController>() != null
        // }   
        
         if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            canDetect = true;
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
