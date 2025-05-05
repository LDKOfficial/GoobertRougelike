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
}
