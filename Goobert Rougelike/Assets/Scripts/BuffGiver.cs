using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BuffGiver : MonoBehaviour
{

    [SerializeField]
    private PlayerStats stats;

    [SerializeField]
    private List<GameObject> buffs;

    [SerializeField]
    private Animator animator;

    private GameObject buff1;
    private GameObject buff2;
    private GameObject buff3;

    private UIDocument uiDocument;

    private List<Button> buffGiverButtons = new List<Button>();
    private Button button1;
    private Button button2;
    private Button button3;



    private void Awake()
    {
        uiDocument = GetComponent<UIDocument>();

        button1 = uiDocument.rootVisualElement.Q("Buff1") as Button;
        button2 = uiDocument.rootVisualElement.Q("Buff2") as Button;
        button3 = uiDocument.rootVisualElement.Q("Buff3") as Button;

        button1.RegisterCallback<ClickEvent>(GiveBuff1);
        button2.RegisterCallback<ClickEvent>(GiveBuff2);
        button3.RegisterCallback<ClickEvent>(GiveBuff3);

        buffGiverButtons = uiDocument.rootVisualElement.Query<Button>().ToList();

        for (int iterator = 0; iterator < buffGiverButtons.Count; iterator++)
        {
            //buffGiverButtons[iterator].RegisterCallback<ClickEvent>();
        }

    }
    private void FixedUpdate()
    {
        if (stats.xpPoints >= stats.xpToNextBuff)
        {
            stats.xpPoints = 0;
            stats.xpToNextBuff = stats.xpToNextBuff * 1.1f;

            buff1 = buffs[Random.Range(0,buffs.Count)];
            buff2 = buffs[Random.Range(0,buffs.Count)];
            buff3 = buffs[Random.Range(0,buffs.Count)];

            animator.SetTrigger("Show");
        }
    }

    private void OnDisable()
    {
        button1.UnregisterCallback<ClickEvent>(GiveBuff1);
        button2.UnregisterCallback<ClickEvent>(GiveBuff2);
        button3.UnregisterCallback<ClickEvent>(GiveBuff2);
        //Mikkel: Maybe make more buutons
    }

    private void GiveBuff1(ClickEvent click)
    {
        stats.attackSpeed += buff1.gameObject.GetComponent<Buff>().attackSpeedChange;
        stats.damage += buff1.gameObject.GetComponent<Buff>().damageChange;
        stats.maxHitPoints += buff1.gameObject.GetComponent<Buff>().maxHitPointsChange;
        stats.moveSpeed += buff1.gameObject.GetComponent<Buff>().moveSpeedChange;
        Debug.Log("Button1 pressed");
        Debug.Log(buff1.gameObject.GetComponent<Buff>().name);

        //animator.SetTrigger("Hide");
    }

    private void GiveBuff2(ClickEvent click)
    {
        stats.attackSpeed += buff2.gameObject.GetComponent<Buff>().attackSpeedChange;
        stats.damage += buff2.gameObject.GetComponent<Buff>().damageChange;
        stats.maxHitPoints += buff2.gameObject.GetComponent<Buff>().maxHitPointsChange;
        stats.moveSpeed += buff2.gameObject.GetComponent<Buff>().moveSpeedChange;
        Debug.Log("Button2 pressed");
        animator.SetTrigger("Hide");
    }

    private void GiveBuff3(ClickEvent click)
    {
        stats.attackSpeed += buff3.gameObject.GetComponent<Buff>().attackSpeedChange;
        stats.damage += buff3.gameObject.GetComponent<Buff>().damageChange;
        stats.maxHitPoints += buff3.gameObject.GetComponent<Buff>().maxHitPointsChange;
        stats.moveSpeed += buff3.gameObject.GetComponent<Buff>().moveSpeedChange;
        Debug.Log("Button3 pressed");
        animator.SetTrigger("Hide");
    }



}
