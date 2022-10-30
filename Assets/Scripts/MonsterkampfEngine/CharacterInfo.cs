using System.Collections;
using System.Collections.Generic;

namespace MonsterkampfEngine
{
    public struct CharacterInfo
    {
        public float CurrentHP, MaxHP, AttackPoints, DefensePoints, AgilityPoints;

        public string Name;

        public CharacterEffect[] Effects;

	    public CharacterInfo(float _maxHp, float _currHp, float _ap, float _dp, float _agp, string _name, CharacterEffect[] _effects)
        {
            MaxHP = _maxHp;
            CurrentHP = _currHp;
            AttackPoints = _ap;
            DefensePoints = _dp;
            AgilityPoints = _agp;
            Name = _name;
            Effects = _effects;
        }
    }
}
