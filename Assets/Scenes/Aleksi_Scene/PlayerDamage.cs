using System.Collections;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    private SpriteRenderer sr;
    private bool canTakeDamage = true;

    private void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if(canTakeDamage == true)
            {
                PlayerHealthNew.instance.applyDamage(1);
                SoundManager.instance.PlaySound("ou");
                StartCoroutine(Invincibility());
            }
        }
    }

    private IEnumerator Invincibility()
    {
        Color originalColor = sr.color;
        Color darkenColor = new Color(sr.color.r, sr.color.g, sr.color.b, .5f);

        canTakeDamage = false;

        sr.color = darkenColor;
        yield return new WaitForSeconds(.1f);

        sr.color = originalColor;
        yield return new WaitForSeconds(.1f);

        sr.color = darkenColor;
        yield return new WaitForSeconds(.15f);

        sr.color = originalColor;
        yield return new WaitForSeconds(.15f);

        sr.color = darkenColor;
        yield return new WaitForSeconds(.25f);

        sr.color = originalColor;
        yield return new WaitForSeconds(.25f);

        sr.color = darkenColor;
        yield return new WaitForSeconds(.3f);

        sr.color = originalColor;
        canTakeDamage = true;
    }
}
