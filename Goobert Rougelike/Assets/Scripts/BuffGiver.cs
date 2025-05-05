using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BuffGiver : MonoBehaviour
{

    [SerializeField]
    private PlayerStats stats;

    [SerializeField]
    private GameObject uI;

    [SerializeField]
    private TextMeshProUGUI button1Titel;
    [SerializeField]
    private TextMeshProUGUI button1Description;

    [SerializeField]
    private TextMeshProUGUI button2Titel;
    [SerializeField]
    private TextMeshProUGUI button2Description;

    [SerializeField]
    private TextMeshProUGUI button3Titel;
    [SerializeField]
    private TextMeshProUGUI button3Description;

    [SerializeField]
    private List<GameObject> buffs;

    private GameObject buff1;
    private GameObject buff2;
    private GameObject buff3;

    private void FixedUpdate()
    {
        if (stats.xpPoints >= stats.xpToNextBuff)
        {
            Debug.Log("Level up");

            stats.level++;

            uI.SetActive(true);

            stats.xpPoints = 0;
            stats.xpToNextBuff = stats.xpToNextBuff * 1.1f;
            buff1 = buffs[Random.Range(0,buffs.Count - 1)];
            buff2 = buffs[Random.Range(0,buffs.Count - 1)];
            buff3 = buffs[Random.Range(0,buffs.Count - 1)];

            button1Titel.text = buff1.name;
            button1Description.text = buff1.GetComponent<Buff>().description;

            button2Titel.text = buff2.name;
            button2Description.text = buff2.GetComponent<Buff>().description;

            button3Titel.text = buff3.name;
            button3Description.text = buff3.GetComponent<Buff>().description;

            Time.timeScale = 0;

        }
    }


    public void GiveBuff1()
    {
        stats.attackSpeed += buff1.gameObject.GetComponent<Buff>().attackSpeedChange;
        stats.damage += buff1.gameObject.GetComponent<Buff>().damageChange;
        stats.maxHitPoints += buff1.gameObject.GetComponent<Buff>().maxHitPointsChange;
        stats.moveSpeed += buff1.gameObject.GetComponent<Buff>().moveSpeedChange;
        Debug.Log("Button1 pressed");
        Debug.Log(buff1.gameObject.GetComponent<Buff>().name);

        uI.SetActive(false);
        Time.timeScale = 1;
    }

    public void GiveBuff2()
    {
        stats.attackSpeed += buff2.gameObject.GetComponent<Buff>().attackSpeedChange;
        stats.damage += buff2.gameObject.GetComponent<Buff>().damageChange;
        stats.maxHitPoints += buff2.gameObject.GetComponent<Buff>().maxHitPointsChange;
        stats.moveSpeed += buff2.gameObject.GetComponent<Buff>().moveSpeedChange;
        Debug.Log("Button2 pressed");
        Debug.Log(buff2.gameObject.GetComponent<Buff>().name);

        uI.SetActive(false);
        Time.timeScale = 1;
    }

    public void GiveBuff3()
    {
        stats.attackSpeed += buff3.gameObject.GetComponent<Buff>().attackSpeedChange;
        stats.damage += buff3.gameObject.GetComponent<Buff>().damageChange;
        stats.maxHitPoints += buff3.gameObject.GetComponent<Buff>().maxHitPointsChange;
        stats.moveSpeed += buff3.gameObject.GetComponent<Buff>().moveSpeedChange;
        Debug.Log("Button3 pressed");
        Debug.Log(buff3.gameObject.GetComponent<Buff>().name);

        uI.SetActive(false);
        Time.timeScale = 1;
    }



}
