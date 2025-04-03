using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    [SerializeField]
    private PlayerStats stats;

    public void RemoveHealth(int damage)
    {
        stats.hitPoints -= damage;

        if (stats.hitPoints <= 0)
        {
            Debug.Log("Player has died");
        }
    }
}
