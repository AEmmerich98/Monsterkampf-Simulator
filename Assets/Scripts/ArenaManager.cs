using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Events;
using UnityEngine;
using UnityEngine.Events;

public class ArenaManager : MonoBehaviour
{
    public AllyCharacterPreset[] Presets;

    private AllyCharacter[] TestCharacters;

    private const int MAXCHARACTERS = 3;

    [SerializeField]
    private GameObject ActionsTab;

    private delegate void MyDelegate(EActions _action);

    // Start is called before the first frame update
    void Start()
    {
        TestCharacters = new AllyCharacter[MAXCHARACTERS];
        TestCharacters[0] = new AllyCharacter(Presets[0]);
        TestCharacters[1] = new AllyCharacter(Presets[1]);
        TestCharacters[2] = new AllyCharacter(Presets[1]);



        SelectableText[] selectableTexts = ActionsTab.GetComponentsInChildren<SelectableText>();
        for (int i = 0; i < TestCharacters[0].Actions.Length; i++)
        {
            //myDelegate = LogAction;
            //myDelegate(TestCharacters[0].Actions[i]);

            //object myObject = selectableTexts[i].mOnConfirm.GetPersistentTarget(0);

            //UnityEventTools.RegisterPersistentListener(selectableTexts[i].mOnConfirm, 0, LogTest);
            selectableTexts[i].mOnConfirm.AddListener(LogTest);

            selectableTexts[i].SetText(TestCharacters[0].Actions[i].ToString());
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
