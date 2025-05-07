using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    [SerializeField]
    private PlayerStats stats;

    [SerializeField]
    private GameEnd gameEnd;

    public void RemoveHealth(int damage)
    {
        stats.hitPoints -= damage;

        if (stats.hitPoints <= 0)
        {
            gameEnd.End();
        }
    }

    public void MaxHealthChange(int maxHealthChange)
    {
        stats.maxHitPoints += maxHealthChange;

        if (stats.hitPoints > stats.maxHitPoints)
        {
            stats.hitPoints = stats.maxHitPoints;
        }
        
        if (maxHealthChange > 0)
        {
            stats.hitPoints += maxHealthChange;
        }
    }
}
