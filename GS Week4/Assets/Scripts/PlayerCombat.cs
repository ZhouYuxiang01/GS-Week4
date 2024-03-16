using System;
using System.Collections;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health of the player
    public int currentHealth; // Current health of the player
    public int attackDamage = 10; // Damage dealt by the player's attack
    public LayerMask enemyLayer; // Layer mask to define what is considered as an enemy
    public float haloRadius = 5f; // Radius of the player's halo
    private Animator animator;
    private PolygonCollider2D hitbox;
    public float time;

    void Start()
    {
        currentHealth = maxHealth; // Initialize current health to maximum health
        animator = GetComponent<Animator>();
        hitbox = GetComponent<PolygonCollider2D>();
    }

    void Update()
    {

        //Attack();

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reduce player's health by the amount of damage taken

        // Check if player's health is depleted
        if (currentHealth <= 0)
        {
            isDied();
        }
    }

    void isDied()
    {
        // Show died animation when player is died
        animator.SetBool("isDied", true);
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


}
