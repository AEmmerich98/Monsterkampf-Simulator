using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public struct Buff
{
    public enum BuffEEffects
    {
        ModifyHealth,
        ModifyAttack,
        ModifyDefense,
        ModifyAgility,
    }

    public BuffEEffects Effect;
    public int Strength, Duration;
    public bool IsDebuff;

    public Buff(BuffEEffects _effect, int _strength, int _duration, bool _isDebuff)
    {
        Effect = _effect;
        Strength = _strength;
        Duration = _duration;
        IsDebuff = _isDebuff;
    }

    public void ReduceDuration()
    {
        Duration -= 1;
    }
}
