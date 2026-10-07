using UnityEngine;
using UnityEngine.Events;

public class PlayerHealthNew : MonoBehaviour
{
    public static PlayerHealthNew instance { get; private set; }

    [Header("Health Settings")]
    public int maxHealth = 3;
    public int currentHealth;
    public int heal = 1;
    public bool takeHeal = false;

    [Header("Damage Settings")]
    public int damage = 1;
    public bool takeDamage = false;

    public UnityEvent<bool> OnDeath;
    public UnityEvent<string> endGame;
    public bool isDead = false;

    //////////////////////////////////////////////////////////////////////
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if (endGame == null)
            endGame = new UnityEvent<string>();
        currentHealth = maxHealth;
        // OnHealthChanged?.Invoke(currentHealth);
        isDead = true;
    }
    //////////////////////////////////////////////////////////////////////

    public void plusHealth(int amount) // Add health
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        // OnHealthChanged?.Invoke(currentHealth);
        // OnHealthAdded?.Invoke();
        Debug.Log("Health added! Current health: " + currentHealth);
    }

    public void minusHealth(int amount) // Remove health
    {
        // currentHealth = Mathf.Max(currentHealth - amount, 0);
        // OnHealthChanged?.Invoke(currentHealth);
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            // OnPlayerDeath?.Invoke();
            Debug.Log("Game Over");

            isDead = true;
            endGame?.Invoke("Game Over");
        }
        else
        {
            Debug.Log("Current health: " + currentHealth);
        }
    }

    public void resetHealth() // Reset health
    {
        currentHealth = maxHealth;
        // OnHealthChanged?.Invoke(currentHealth);
    }

    public void applyHeal(int heal)
    {
        plusHealth(heal);
        takeHeal = true;
    }

    public void applyDamage(int damage)
    {
        minusHealth(damage);
        takeDamage = true;
    }
}
