using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DebugPanelController : MonoBehaviour
{
    private ArenaManager arenaManager;
    [SerializeField]
    private GameObject[] controlPanels;
    [SerializeField]
    private DebugCharacterSelector AttackerSelector, TargetSelector;

    private int acitvePanelIndex = 1;

    // Start is called before the first frame update
    void Start()
    {
        arenaManager = ArenaManager.Instance;
    }

    public void DebugAttack()
    {
        arenaManager.TestCharacters[AttackerSelector.selectedCharacterIndex].Attack(arenaManager.TestCharacters[TargetSelector.selectedCharacterIndex], true);
        TargetSelector.UpdateText();
        AttackerSelector.UpdateText();
    }

    public void NextPanel()
    {
        controlPanels[acitvePanelIndex].SetActive(false);

        if (++acitvePanelIndex >= controlPanels.Length)
        {
            acitvePanelIndex = 0;
        }

        controlPanels[acitvePanelIndex].SetActive(true);
    }

    public void PrevPanel()
    {
        controlPanels[acitvePanelIndex].SetActive(false);

        if (--acitvePanelIndex < 0)
        {
            acitvePanelIndex = controlPanels.Length - 1;
        }

        controlPanels[acitvePanelIndex].SetActive(true);
    }
}
