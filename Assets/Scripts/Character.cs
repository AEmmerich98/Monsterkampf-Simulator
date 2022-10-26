﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unity.VisualScripting;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public abstract class Character
{
    //protected
    protected float CurrentHP, MaxHP, AttackPoints, DefensePoints, AgilityPoints;
	protected const float UPPER_DAMAGE_MULTI = 1.35f, LOWER_DAMAGE_MULTI = 0.85f;

    public float GetCurrentHP { get => CurrentHP; }
    public float GetMaxHP { get => MaxHP; }
    public float GetAP { get => AttackPoints; }
    public float GetDP { get => DefensePoints; }
    public float GetAgP { get => AgilityPoints; }

    //Stack?
	private List<Buff> ActiveBuffs = new List<Buff>();

    public Character(float _hp, float _ap, float _dp, float _agp)
    {
        MaxHP = _hp;
        CurrentHP = _hp;
        AttackPoints = _ap;
        DefensePoints = _dp;
        AgilityPoints = _agp;
    }

	public void Attack(Character _target)
	{
        System.Random random = new System.Random();

        if (AttackPoints * random.Next(1, 11) * 0.20f > _target.GetAgP)
		{
            //Hit
            float dmg = (float)(AttackPoints * (random.NextDouble() * (UPPER_DAMAGE_MULTI - LOWER_DAMAGE_MULTI) + LOWER_DAMAGE_MULTI));
			_target.TakeDamage(dmg);
			random.Next();
        }
		else
		{
			//Miss
		}
	}
	public void TakeDamage(float _dmg)
	{
        if (_dmg > AttackPoints)
        {
            CurrentHP -= _dmg - DefensePoints;
        }
	}

	public void AddBuff(ref Buff _buff)
	{
        ApplyBuffEffect(ref _buff);
		ActiveBuffs.Add(_buff);
	}

	public void ApplyBuffEffect(ref Buff _buff)
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
            case Buff.BuffEEffects.ModifyHealth:
                if (!_buff.IsDebuff)
                    CurrentHP += _buff.Strength * mod;
                else
                    CurrentHP -= _buff.Strength * mod;
                break;

            case Buff.BuffEEffects.ModifyAttack:
                if (!_buff.IsDebuff)
                    AttackPoints *= _buff.Strength * mod;
                else
                    AttackPoints *= -(_buff.Strength) * mod;
                break;

            case Buff.BuffEEffects.ModifyDefense:
                if (!_buff.IsDebuff)
                    DefensePoints *= _buff.Strength * mod;
                else
                    DefensePoints *= -(_buff.Strength) * mod;
                break;

            case Buff.BuffEEffects.ModifyAgility:
                if (!_buff.IsDebuff)
                    AgilityPoints *= _buff.Strength * mod;
                else
                    AgilityPoints *= -(_buff.Strength) * mod;
                break;
        }

        //VALUE TYPE UNDSO, GEHT SO NICHT
        if (!BuffExpired)
        {
            _buff.ReduceDuration();
        }
        else
        {
            _buff.ReduceDuration();
        }
    }

    public void ResolveBuffs()
	{
        for (int i = 0; i < ActiveBuffs.Count; i++)
        {
            Buff buff = ActiveBuffs[i];
            ApplyBuffEffect(ref buff);
            ActiveBuffs[i] = buff;
        }
        
        //Remove expired Buffs
	}

    public void ClearBuffs()
    {
        ActiveBuffs.Clear();
    }
}
