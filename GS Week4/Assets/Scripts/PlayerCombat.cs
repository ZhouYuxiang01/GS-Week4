using System;
using System.Collections;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public GameManager gameManager;
    public int maxHealth = 100; // Maximum health of the player
    public int currentHealth; // Current health of the player
    public int attackDamage = 10; // Damage dealt by the player's attack
    public LayerMask enemy; // Layer mask to define what is considered as an enemy
    public float haloRadius = 5f; // Radius of the player's halo
    public Animator animator;
    private SpriteRenderer spriteRenderer;
    public float flashDuration = 0.1f; // 受伤闪烁的持续时间
    public AudioClip hurtSound;
    private Color originalColor;

    void Start()
    {
        currentHealth = maxHealth; // Initialize current health to maximum health
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    void Update()
    {
        //Attack();

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reduce player's health by the amount of damage taken
        StartCoroutine(FlashColor(flashDuration));
        GetComponent<AudioSource>().PlayOneShot(hurtSound);
        // Check if player's health is depleted
        if (currentHealth <= 0)
        {
            isDied();
        }
    }

    IEnumerator FlashColor(float duration)
    {
        // 受伤时变为红色
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(duration);

        spriteRenderer.color = originalColor;
    }


    void isDied()
    {
        // Show died animation when player is died
        animator.SetBool("isDied", true);
        gameManager.GameOver();
        // Perform actions upon player's death, such as game over or respawn
        Debug.Log("Player died.");

        // You can add more functionality here, like restarting the game or showing a game over screen.
        Destroy(gameObject);
    }

    // Visualize halo radius in the editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, haloRadius);
    }


}
