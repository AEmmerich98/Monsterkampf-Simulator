using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MonsterkampfEngine
{
    public abstract class Character
    {

        //protected
        protected float CurrentHP, MaxHP, AttackPoints, DefensePoints, AgilityPoints;
        protected const float UPPER_DAMAGE_MULTI = 1.35f, LOWER_DAMAGE_MULTI = 0.85f;

        protected string Name;

        public CharacterInfo characterInfo;

        //Redundant?
        public float GetCurrentHP { get => CurrentHP; }
        public float GetMaxHP { get => MaxHP; }
        public float GetAP { get => AttackPoints; }
        public float GetDP { get => DefensePoints; }
        public float GetAgP { get => AgilityPoints; }
        public string GetName { get => Name; }

        //Stack?
        private List<CharacterEffect> Effects = new List<CharacterEffect>();

        public Character(float _hp, float _ap, float _dp, float _agp, string _name)
        {
            MaxHP = _hp;
            CurrentHP = _hp;
            AttackPoints = _ap;
            DefensePoints = _dp;
            AgilityPoints = _agp;
            Name = _name;

            characterInfo = new CharacterInfo(MaxHP, CurrentHP, AttackPoints, DefensePoints, AgilityPoints, Name, Effects.ToArray());
        }

        public bool Attack(Character _target, bool _logInConsole = false, bool _logInBattleLog = false)
        {
            bool success = false;

            System.Random random = new System.Random();
            int attackAccuracyMultiplier = random.Next(0, 11);
            double dmgMultiplier = random.NextDouble() * (UPPER_DAMAGE_MULTI - LOWER_DAMAGE_MULTI) + LOWER_DAMAGE_MULTI;

            //Trefferformel: Erfolgreich wenn Angriffspunkte * Angriffsgenauigkeits Multiplikator(0 - 2) > Agilitätspunkte des Ziels
            if (AttackPoints * attackAccuracyMultiplier * 0.20f > _target.GetAgP)
            {
                success = true;

                //Schadensformel: Schaden = Angriffspunkte * Schadens Multiplikator(0.85 - 1.35)
                float dmg = (float)(AttackPoints * dmgMultiplier);

                if (_logInConsole)
                {
                    //Debug.Log(this.Name + ": attacked " + _target.Name + " and hit! (" + AttackPoints + " * " + attackAccuracyMultiplier + " * "  + 0.20f + " = " + (AttackPoints * attackAccuracyMultiplier * 0.20f) +  " > " + _target.GetAgP + " -> " + dmg + " = " + AttackPoints * dmgMultiplier + ")");
                }
                else if (_logInBattleLog)
                {

                }
                _target.TakeDamage(dmg, _logInConsole, _logInBattleLog);

                //random.Next();

            }
            else
            {
                if (_logInConsole)
                {
                    //Debug.Log(this.Name + ": attacked " + _target.Name + " and missed!");
                }
                else if (_logInBattleLog)
                {

                }
            }

            return success;
        }
        public bool TakeDamage(float _dmg, bool _logInConsole = false, bool _logInBattleLog = false)
        {
            bool success = false;

            if (_dmg > DefensePoints)
            {
                success = true;

                CurrentHP -= _dmg - DefensePoints;
            }

            if (_logInConsole)
            {
                if (success)
                {
                    //Debug.Log(Name + ": took " + (_dmg - DefensePoints) + " damage! (" + _dmg + " > " + DefensePoints + " -> " + (_dmg - DefensePoints) + " = " + _dmg + " - " + DefensePoints + ")");
                }
                else
                {
                    //Debug.Log(Name + ": took no damage! (" + _dmg + " > " + DefensePoints + ", " + (_dmg - DefensePoints) + " = " + _dmg + " - " + DefensePoints + ")");
                }

            }
            if (_logInBattleLog)
            {

            }

            return success;
        }

        public void AddBuff(ref CharacterEffect _buff, bool _logInConsole = false, bool _logInBattleLog = false)
        {
            ApplyBuffEffect(ref _buff);
            Effects.Add(_buff);

            if (_logInConsole)
            {

            }
            if (_logInBattleLog)
            {

            }
        }

        public void ApplyBuffEffect(ref CharacterEffect _buff, bool _logInConsole = false, bool _logInBattleLog = false)
        {
            int mod = 1;
            bool BuffExpired = false;


            if (_buff.Duration == 0)
            {
                mod = -1;
                BuffExpired = true;
            }

            switch (_buff.Effect)
            {
                case CharacterEffect.EEffectedAttribute.ModifyHealth:
                    if (_buff.EffectType == CharacterEffect.EEffectType.Buff)
                        CurrentHP += _buff.Strength * mod;
                    else
                        CurrentHP -= _buff.Strength * mod;
                    break;

                case CharacterEffect.EEffectedAttribute.ModifyAttack:
                    if (_buff.EffectType == CharacterEffect.EEffectType.Buff)
                        AttackPoints *= _buff.Strength * mod;
                    else
                        AttackPoints *= -(_buff.Strength) * mod;
                    break;

                case CharacterEffect.EEffectedAttribute.ModifyDefense:
                    if (_buff.EffectType == CharacterEffect.EEffectType.Buff)
                        DefensePoints *= _buff.Strength * mod;
                    else
                        DefensePoints *= -(_buff.Strength) * mod;
                    break;

                case CharacterEffect.EEffectedAttribute.ModifyAgility:
                    if (_buff.EffectType == CharacterEffect.EEffectType.Buff)
                        AgilityPoints *= _buff.Strength * mod;
                    else
                        AgilityPoints *= -(_buff.Strength) * mod;
                    break;
            }

            //VALUE TYPE UNDSO
            if (!BuffExpired)
            {
                _buff.ReduceDuration();
            }
            else
            {
                _buff.ReduceDuration();
            }

            if (_logInConsole)
            {

            }
            if (_logInBattleLog)
            {

            }
        }

        public void ResolveBuffs(bool _logInConsole = false, bool _logInBattleLog = false)
        {
            for (int i = 0; i < Effects.Count; i++)
            {
                CharacterEffect buff = Effects[i];
                ApplyBuffEffect(ref buff);
                Effects[i] = buff;
            }

            //Remove expired Buffs
            if (_logInConsole)
            {

            }
            if (_logInBattleLog)
            {

            }
        }

        public void ClearBuffs(bool _logInConsole = false, bool _logInBattleLog = false)
        {
            Effects.Clear();

            if (_logInConsole)
            {

            }
            if (_logInBattleLog)
            {

            }
        }
    }
}
