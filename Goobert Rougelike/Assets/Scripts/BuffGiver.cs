using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BuffGiver : MonoBehaviour
{

    [SerializeField]
    private PlayerStats stats;

    [SerializeField]
    private List<GameObject> buffs;

    private GameObject buff1;
    private GameObject buff2;
    private GameObject buff3;

    private UIDocument uiDocument;

    private Button button1;
    private Button button2;
    private Button button3;

    private void Awake()
    {
        uiDocument = GetComponent<UIDocument>();

        button1 = uiDocument.rootVisualElement.Q("Buff1") as Button;
        button2 = uiDocument.rootVisualElement.Q("Buff2") as Button;
        button3 = uiDocument.rootVisualElement.Q("Buff3") as Button;

        button1.RegisterCallback<ClickEvent>(OnPlayerGameClick);
        button2.RegisterCallback<ClickEvent>(OnPlayerGameClick);
        button3.RegisterCallback<ClickEvent>(OnPlayerGameClick);

    }

    private void OnClickDisable()
    {
        button1.UnregisterCallback<ClickEvent>(OnPlayerGameClick);
        //Mikkel: Maybe make more buutons
    }

    private void OnPlayerGameClick(ClickEvent click)
    {
        Debug.Log("Button pressed");
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
        }
    }


}
