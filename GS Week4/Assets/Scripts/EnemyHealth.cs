using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 50; // Maximum health of the enemy
    public int currentHealth; // Current health of the enemy

    void Start()
    {
        currentHealth = maxHealth; // Initialize current health to maximum health
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reduce enemy's health by the amount of damage taken

        // Check if enemy's health is depleted
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Perform actions upon enemy's death, such as dropping loot or playing death animation
        Destroy(gameObject); // Destroy the enemy GameObject
    }
}
