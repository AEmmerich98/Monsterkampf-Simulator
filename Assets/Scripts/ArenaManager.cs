using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Events;
using UnityEngine;
using UnityEngine.Events;
using MonsterkampfEngine;

public class ArenaManager : MonoBehaviour
{
    public static ArenaManager Instance;

    public AllyCharacterPreset[] AllyPresets;
    //public EnemyPreset[] EnemyPresets;

    public Character[] TestCharacters;
    //public CharacterInfo[] TestCharactersInfos;

    private const int MAXALLIES = 3;
    private const int MAXENEMIES = 6;

    [SerializeField]
    private GameObject ActionsTab;

    private delegate void MyDelegate(EActions _action);

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }


        
        for (int i = 0; i < 3; i++)
        {
            //wird 3 mal ausgeführt
        }

        int numberOfRepeats = 3;
        for (int i = 0; i < numberOfRepeats; i++)
        {
            //wird 3 mal ausgeführt
        }

        //DontDestroyOnLoad(this.gameObject);

        TestCharacters = new Character[MAXALLIES + MAXENEMIES];
        for (int i = 0; i < MAXALLIES; i++)
        {
            TestCharacters[i] = new AllyCharacter(AllyPresets[i].MaxHp, AllyPresets[i].AttackPoints, AllyPresets[i].DefensePoints, AllyPresets[i].AgilityPoints, "Ally" + i, AllyPresets[i].CharacterClass, AllyPresets[i].Actions);
            //TestCharactersInfos[i] = TestCharacters[i].characterInfo;
        }

        for (int i = MAXALLIES; i < MAXALLIES + MAXENEMIES; i++)
        {
            TestCharacters[i] = new Enemy(50f, 15f, 2.5f, 2.5f, "Enemy" + (i - MAXALLIES));
            //TestCharactersInfos[i] = TestCharacters[i].characterInfo;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SelectableText[] selectableTexts = ActionsTab.GetComponentsInChildren<SelectableText>();
        AllyCharacter[] allies = { (AllyCharacter)TestCharacters[0], (AllyCharacter)TestCharacters[1], (AllyCharacter)TestCharacters[2] };

        for (int i = 0; i < allies[0].Actions.Length; i++)
        {
            //myDelegate = LogAction;
            //myDelegate(TestCharacters[0].Actions[i]);

            //object myObject = selectableTexts[i].mOnConfirm.GetPersistentTarget(0);

            //UnityEventTools.RegisterPersistentListener(selectableTexts[i].mOnConfirm, 0, LogTest);
            selectableTexts[i].mOnConfirm.AddListener(LogTest);

            selectableTexts[i].SetText(allies[0].Actions[i].ToString());
        }

        //Debug.Log(TestCharacters[1].CurrentHp);


        //TestCharacters[0].Attack(TestCharacters[1]);


        //Debug.Log(TestCharacters[1].CurrentHp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LogAction(EActions _action)
    {
        Debug.Log(_action.ToString());
    }

    public void LogTest()
    {
        Debug.Log("TEST");
    }
}
