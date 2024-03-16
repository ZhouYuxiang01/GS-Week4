using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health of the player
    public int currentHealth; // Current health of the player
    public int attackDamage = 10; // Damage dealt by the player's attack
    public LayerMask enemyLayer; // Layer mask to define what is considered as an enemy
    public float haloRadius = 5f; // Radius of the player's halo

    void Start()
    {
        currentHealth = maxHealth; // Initialize current health to maximum health
    }

    void Update()
    {
        // Check for player attack input
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
    }

    void Attack()
    {
        // Detect enemies within the halo radius
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, haloRadius, enemyLayer);

        // Damage each enemy within the halo
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reduce player's health by the amount of damage taken

        // Check if player's health is depleted
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Perform actions upon player's death, such as game over or respawn
        Debug.Log("Player died.");
        // You can add more functionality here, like restarting the game or showing a game over screen.
    }

    // Visualize halo radius in the editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, haloRadius);
    }

    // Check for enemies entering the player's halo
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Attack enemies within the halo when they stay inside it
            Attack();
        }
    }
}
