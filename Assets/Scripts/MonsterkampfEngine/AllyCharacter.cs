using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonsterkampfEngine
{
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

        public AllyCharacter(float _hp, float _ap, float _dp, float _agp, string _name, EClasses _class, EActions[] _actions) : base(_hp, _ap, _dp, _agp, _name)
        {
            Class = _class;
            Actions = _actions;
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
            CharacterEffect b = new CharacterEffect(CharacterEffect.EEffectType.Buff, CharacterEffect.EEffectedAttribute.ModifyDefense, 2, 1);
            AddBuff(ref b);
        }

        private void Dodge()
        {
            CharacterEffect b = new CharacterEffect(CharacterEffect.EEffectType.Buff, CharacterEffect.EEffectedAttribute.ModifyAgility, 2, 1);
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
}

