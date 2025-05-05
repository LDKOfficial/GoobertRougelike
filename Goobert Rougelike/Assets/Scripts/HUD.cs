using System;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]
    private PlayerStats stats;


    [SerializeField]
    private TextMeshProUGUI timer;
    private float secondsCount;
    private int minutesCount;

    [SerializeField]
    private Slider healthBar;

    [SerializeField]
    private Slider xPBar;

    [SerializeField]
    private TextMeshProUGUI attackSpeed; 

    [SerializeField]
    private TextMeshProUGUI attackDamage;

    [SerializeField]
    private TextMeshProUGUI moveSpeed;  

    public string timerText;
    private void FixedUpdate()
    {
        UpdateTimer();
        UpdateHealthBar();
        UpdateXPBar();

        attackSpeed.text = $"{stats.attackSpeed}";
        attackDamage.text = $"{stats.damage}";
        moveSpeed.text = $"{stats.moveSpeed}";
    }

    private void UpdateTimer()
    {
        secondsCount += Time.deltaTime;

        if(secondsCount >= 60f)
        {
            minutesCount++;
            secondsCount = 0;
        }

        timerText = $"{minutesCount}:{Convert.ToInt32(secondsCount)}";
        timer.text = timerText;
    }

    private void UpdateHealthBar()
    {
        healthBar.maxValue = stats.GetComponent<PlayerStats>().maxHitPoints;
        healthBar.value = stats.GetComponent<PlayerStats>().hitPoints;
    }

    private void UpdateXPBar()
    {
        xPBar.maxValue = stats.GetComponent<PlayerStats>().xpToNextBuff;
        xPBar.value = stats.GetComponent<PlayerStats>().xpPoints;
    }
}
