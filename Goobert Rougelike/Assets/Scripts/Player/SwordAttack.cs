using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    private List<GameObject> enemiesInRange = new List<GameObject>();

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("enemy"))
        {
            enemiesInRange.Add(col.gameObject);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if(col.gameObject.CompareTag("enemy"))
            {
                enemiesInRange.Remove(col.gameObject);
            }
    }

    public void Attack()
    {
        
    }

}
