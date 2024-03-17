using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    private PolygonCollider2D hitbox;
    public int attackDamage = 10;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        animator = transform.parent.GetComponent<Animator>();
        hitbox = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        Attack();
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            hitbox.enabled = true;

            animator.SetTrigger("attack");
            StartCoroutine(disableHitBox());

        } 

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyPatrol>().TakeDamage(attackDamage);
        }
    }

    IEnumerator disableHitBox()
    {
        yield return new WaitForSeconds(time);
        hitbox.enabled = false;
    }
}
