using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[CreateAssetMenu(fileName = "new AllyCharacterPreset", menuName = "AllyCharacterPreset")]
public class AllyCharacterPreset : ScriptableObject
{
    //[SerializeField]
    public EClasses CharacterClass;

    //[SerializeField]
    public EActions[] Actions;

    //[SerializeField]
    public float MaxHp, AttackPoints, DefensePoints, AgilityPoints;
}