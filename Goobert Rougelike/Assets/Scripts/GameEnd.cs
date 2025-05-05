using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{

    [SerializeField]
    private GameObject endScreen;

    [SerializeField]
    private GameObject hud;

    [SerializeField]
    private PlayerStats stats;

    [SerializeField]
    private TextMeshProUGUI attackSpeed; 

    [SerializeField]
    private TextMeshProUGUI attackDamage;

    [SerializeField]
    private TextMeshProUGUI moveSpeed;  
    
    [SerializeField]
    private TextMeshProUGUI timer;

    [SerializeField]
    private TextMeshProUGUI level;

    [SerializeField]
    private TextMeshProUGUI maxHealth;

    public void End()
    {
        Time.timeScale = 0;

        stats.timeSurvived = hud.GetComponent<HUD>().timerText;

        timer.text = stats.timeSurvived;

        attackSpeed.text = $"{stats.attackSpeed}";
        attackDamage.text = $"{stats.damage}";
        moveSpeed.text = $"{stats.moveSpeed}";
        maxHealth.text = $"{stats.maxHitPoints}";
        level.text = $"{stats.level}";

        hud.SetActive(false);

        endScreen.SetActive(true);

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

}
