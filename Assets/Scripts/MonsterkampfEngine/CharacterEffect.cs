using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonsterkampfEngine
{
    public struct CharacterEffect
    {
        public enum EEffectType
        {
            Buff,
            Debuff
        }

        public enum EEffectedAttribute
        {
            ModifyHealth,
            ModifyAttack,
            ModifyDefense,
            ModifyAgility,
        }

        public EEffectType EffectType;
        public EEffectedAttribute Effect;
        public int Strength, Duration;

        public CharacterEffect(EEffectType _effectType, EEffectedAttribute _effectAttribute, int _strength, int _duration)
        {
            EffectType = _effectType;
            Effect = _effectAttribute;
            Strength = _strength;
            Duration = _duration;
        }

        public void ReduceDuration()
        {
            Duration -= 1;
        }
    }
}
