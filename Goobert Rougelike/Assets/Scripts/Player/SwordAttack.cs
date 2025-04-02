using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{


    [SerializeField]
    private Animator animator;

    [SerializeField]
    private float meleeSpeed;

    [SerializeField]
    private float damage;

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
            timeUntilMelee = meleeSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Enemy")
        {
            Debug.Log("Enemy Hit");
            collider.GetComponent<Enemy>().TakeDamage(damage);
        }
    }


}
