using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    [SerializeField]
    private int health;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private int damage;

    [SerializeField]
    private int xpAmount;

    [SerializeField]
    private Rigidbody2D enemyRigidbody;

    private PlayerStats stats;

    private GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }
    private void FixedUpdate()
    {
        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();

        enemyRigidbody.linearVelocity = direction * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            collider.GetComponent<PlayerHealthManager>().RemoveHealth(damage);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Enemy damage taken");
        if (health <= 0f)
        {
            player.gameObject.GetComponent<PlayerStats>().xpPoints += xpAmount;
            Destroy(gameObject);
        }
    }


}
