using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance { get; private set; }

    [Header("Health Settings")]
    public int maxHealth = 3;
    public int currentHealth;
    public int heal = 1;
    public bool takeHeal = false;

    [Header("Damage Settings")]
    public int damage = 1;
    public bool takeDamage = false;

    // [Header("Events")]
    // public UnityEvent<int> OnHealthChanged;
    // public UnityEvent OnHealthAdded;
    public UnityEvent<bool> OnDeath;
    private bool isDead = false;


    //////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////
    void Start()
    {
        currentHealth = maxHealth;
        // OnHealthChanged?.Invoke(currentHealth);
    }
    //////////////////////////////////////////////////////////////////////
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
            OnDeath?.Invoke(isDead);
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
