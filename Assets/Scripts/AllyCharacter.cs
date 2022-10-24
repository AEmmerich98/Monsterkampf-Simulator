using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;

public enum EClasses
{
    Warrior,
    Mage
}

public enum EActions
{
    Attack,
    Block,
    Dodge,
    UseMgagic,
    UseSkill,
    UseItem,
    Flee
}

public class AllyCharacter : Character
{
    private EClasses Class;
    public EActions[] Actions;

    public AllyCharacter(AllyCharacterPreset _preset) : base(_preset.MaxHp, _preset.AttackPoints, _preset.DefensePoints, _preset.AgilityPoints)
    {
        Class = _preset.CharacterClass;
        Actions = _preset.Actions;
    }

    public void UseAction(EActions _action)
    {
        switch (_action)
        {
            case EActions.Attack:
                break;
            case EActions.Block:
                break;
            case EActions.Dodge:
                break;
            case EActions.UseMgagic:
                break;
            case EActions.UseSkill:
                break;
            case EActions.UseItem:
                break;
            default:
                break;
        }
    }

    private void Block()
    {
        Buff b = new Buff(Buff.BuffEEffects.ModifyDefense, 2, 1, false);
        AddBuff(ref b);
    }

    private void Dodge()
    {
        Buff b = new Buff(Buff.BuffEEffects.ModifyAgility, 2, 1, false);
        AddBuff(ref b);
    }

    private void UseMagic()
    {

    }

    private void UseSkill()
    {

    }

    private void UseItem()
    {

    }
}
