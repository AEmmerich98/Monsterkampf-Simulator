using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using MonsterkampfEngine;

public class DebugCharacterSelector : MonoBehaviour
{
    public int selectedCharacterIndex;

    private ArenaManager arenaManager;

    //private DebugPanelController debugPanelController;
    private MonsterkampfEngine.CharacterInfo selectedCharacterInfo;

    [SerializeField]
    private GameObject allySliderGroup, enemySliderGroup;
    [SerializeField]
    private Slider allySlider, enemySlider;
    [SerializeField]
    private Toggle toggle;
    [SerializeField]
    private TMP_Text nameValueText, hpValueText, apValueText, dpValueText, agpValueText;

    // Start is called before the first frame update
    void Start()
    {
        arenaManager = ArenaManager.Instance;
        //debugPanelController = FindObjectOfType<DebugPanelController>();

        OnSliderValueChanged();
    }

    public void OnToggleValueChanged()
    {
        enemySliderGroup.SetActive(toggle.isOn);
        allySliderGroup.SetActive(!toggle.isOn);

        OnSliderValueChanged();
    }

    public void OnSliderValueChanged()
    {
        if (toggle.isOn)
        {
            selectedCharacterIndex = (int)enemySlider.value + 3;
            selectedCharacterInfo = arenaManager.TestCharacters[selectedCharacterIndex].characterInfo;
        }
        else
        {
            selectedCharacterIndex = (int)allySlider.value;
            selectedCharacterInfo = arenaManager.TestCharacters[selectedCharacterIndex].characterInfo;
        }

        UpdateText();
    }

    public void UpdateText()
    {
        nameValueText.text = selectedCharacterInfo.Name;
        hpValueText.text = arenaManager.TestCharacters[selectedCharacterIndex].GetCurrentHP.ToString("F1") + "/" + arenaManager.TestCharacters[selectedCharacterIndex].GetMaxHP.ToString("F1");
        apValueText.text = arenaManager.TestCharacters[selectedCharacterIndex].GetAP.ToString("F1") + "/" + selectedCharacterInfo.AttackPoints.ToString("F1");
        dpValueText.text = arenaManager.TestCharacters[selectedCharacterIndex].GetDP.ToString("F1") + "/" + selectedCharacterInfo.DefensePoints.ToString("F1");
        agpValueText.text = arenaManager.TestCharacters[selectedCharacterIndex].GetAgP.ToString("F1") + "/" + selectedCharacterInfo.AgilityPoints.ToString("F1");


        //hpValueText.text = selectedCharacterInfo.CurrentHP + "/" + selectedCharacterInfo.MaxHP;
        //apValueText.text = selectedCharacterInfo.AttackPoints + "";
        //dpValueText.text = selectedCharacterInfo.DefensePoints + "";
        //agpValueText.text = selectedCharacterInfo.AgilityPoints + "";
    }
}
