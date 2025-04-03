using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{

    [SerializeField]
    private PlayerStats stats;

    [SerializeField]
    private Animator animator;

    private float timeUntilMelee;

    private void FixedUpdate()
    {
        timeUntilMelee -= Time.deltaTime;
    }

    public void Attack()
    {
        if (timeUntilMelee <= 0f)
        {
            animator.SetTrigger("Attack");
            timeUntilMelee = stats.attackSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Enemy")
        {
            Debug.Log("Enemy Hit");
            collider.GetComponent<Enemy>().TakeDamage(stats.damage);
        }
    }


}
