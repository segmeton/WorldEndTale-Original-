using UnityEngine;
using System.Collections;

public class DamageCalculation 
{
    private static float dmgVarMod = 0.3f;
    private int damage;
    private int totalDamage;

    public int AttackDamage(BaseUnit attacker, BaseUnit attacked)
    {
        int accLimiter = 0;
        if (attacker.Acc > attacked.Agi)
        {
            accLimiter = 0;
        }
        else
        {
            accLimiter = (int)((attacked.Agi / attacker.Acc) * 10);
            if (accLimiter > 80)
            {
                accLimiter = 80;
            }
        }
        int atkAcc = 100 - accLimiter;
        int randomAcc = Random.Range(0,100);
        if (randomAcc < atkAcc)
        {
            damage = (int)(1.5 * attacker.Str) - attacked.End;
            damage = damage + (int)Random.Range(-(damage * dmgVarMod), damage * dmgVarMod);
            int randomCrit = Random.Range(0, 100);
            int critChance = (attacker.Acc / 40) + (attacker.Agi / 4);
            if (randomCrit < critChance)
            {
                damage = (int)(damage * 1.2);
            }
            if (damage >= 0)
            {
                totalDamage = damage;
            }
            else
            {
                totalDamage = 0;
            }
        }
        else
        {
            totalDamage = 0;
        }
        return totalDamage;
    }

    public int CharSkillDamage(BaseUnit attacker, BaseEnemy attacked, BaseAbility skillUsed)    
    {
        int accLimiter = 0;
        if (attacker.Acc > attacked.Agi)
        {
            accLimiter = 0;
        }
        else
        {
            accLimiter = (int)((attacked.Agi / attacker.Acc) * 10);
            if (accLimiter > 80)
            {
                accLimiter = 80;
            }
        }
        int atkAcc = 100 - accLimiter;
        int randomAcc = Random.Range(0, 100);
        if (randomAcc < atkAcc)
        {
            if (skillUsed.SkillType == BaseAbility.Type.MAGICAL)
            {
                damage = (int)(0.4 * skillUsed.BasePower) + (int)(0.6 * attacker.Mag) - attacked.End;
            }
            else if (skillUsed.SkillType == BaseAbility.Type.PHYSICAL)
            {
                damage = (int)(0.4 * skillUsed.BasePower) + (int)(0.6 * attacker.Str) - attacked.End;
            }
            damage = damage + (int)Random.Range(-(damage * dmgVarMod), damage * dmgVarMod);
            if (skillUsed.Element.ElementType != BaseElement.Element.NEUTRAL)
            {
                if (skillUsed.Element.ElementType == BaseElement.Element.WATER)
                {
                    if (attacked.Element.ElementType == BaseElement.Element.FIRE)
                    {
                        damage = (int)(damage * 1.4);
                    }
                    else if (attacked.Element.ElementType == BaseElement.Element.WATER || attacked.Element.ElementType == BaseElement.Element.ELECTRIC)
                    {
                        damage = (int)(damage * 0.6);
                    }
                }
                else if (skillUsed.Element.ElementType == BaseElement.Element.FIRE)
                {
                    if (attacked.Element.ElementType == BaseElement.Element.WIND)
                    {
                        damage = (int)(damage * 1.4);
                    }
                    else if (attacked.Element.ElementType == BaseElement.Element.WATER || attacked.Element.ElementType == BaseElement.Element.FIRE)
                    {
                        damage = (int)(damage * 0.6);
                    }
                }
                else if (skillUsed.Element.ElementType == BaseElement.Element.WIND)
                {
                    if (attacked.Element.ElementType == BaseElement.Element.EARTH)
                    {
                        damage = (int)(damage * 1.4);
                    }
                    else if (attacked.Element.ElementType == BaseElement.Element.WIND || attacked.Element.ElementType == BaseElement.Element.FIRE)
                    {
                        damage = (int)(damage * 0.6);
                    }
                }
                else if (skillUsed.Element.ElementType == BaseElement.Element.EARTH)
                {
                    if (attacked.Element.ElementType == BaseElement.Element.ELECTRIC)
                    {
                        damage = (int)(damage * 1.4);
                    }
                    else if (attacked.Element.ElementType == BaseElement.Element.EARTH || attacked.Element.ElementType == BaseElement.Element.WIND)
                    {
                        damage = (int)(damage * 0.6);
                    }
                }
                else if (skillUsed.Element.ElementType == BaseElement.Element.ELECTRIC)
                {
                    if (attacked.Element.ElementType == BaseElement.Element.WATER)
                    {
                        damage = (int)(damage * 1.4);
                    }
                    else if (attacked.Element.ElementType == BaseElement.Element.ELECTRIC || attacked.Element.ElementType == BaseElement.Element.EARTH)
                    {
                        damage = (int)(damage * 0.6);
                    }
                }
                else if (skillUsed.Element.ElementType == BaseElement.Element.LIGHT)
                {
                    if (attacked.Element.ElementType == BaseElement.Element.DARK)
                    {
                        damage = (int)(damage * 1.4);
                    }
                    else if (attacked.Element.ElementType == BaseElement.Element.LIGHT)
                    {
                        damage = (int)(damage * 0.6);
                    }
                }
                else if (skillUsed.Element.ElementType == BaseElement.Element.DARK)
                {
                    if (attacked.Element.ElementType == BaseElement.Element.LIGHT)
                    {
                        damage = (int)(damage * 1.4);
                    }
                    else if (attacked.Element.ElementType == BaseElement.Element.DARK)
                    {
                        damage = (int)(damage * 0.6);
                    }
                }
            }
            int randomCrit = Random.Range(0, 100);
            int critChance = (attacker.Acc / 40) + (attacker.Agi / 4);
            if (randomCrit < critChance)
            {
                damage = (int)(damage * 1.2);
            }
            if (damage >= 0)
            {
                totalDamage = damage;
            }
            else
            {
                totalDamage = 0;
            }
        }
        else
        {
            totalDamage = 0;
        }
        return totalDamage;
    }

    public int HealPoint(BaseUnit healer, BaseAbility skillUsed)
    {
        int heal = (int)(0.4 * skillUsed.BasePower) + (int)(0.6 * healer.Mag);
        return heal;
    }

    public int EnemySkillDamage(BaseUnit attacker, BaseUnit attacked, BaseAbility skillUsed)
    {
        int accLimiter = 0;
        if (attacker.Acc > attacked.Agi)
        {
            accLimiter = 0;
        }
        else
        {
            accLimiter = (int)((attacked.Agi / attacker.Acc) * 10);
            if (accLimiter > 80)
            {
                accLimiter = 80;
            }
        }
        int atkAcc = 100 - accLimiter;
        int randomAcc = Random.Range(0, 100);
        if (randomAcc < atkAcc)
        {
            if (skillUsed.SkillType == BaseAbility.Type.MAGICAL)
            {
                damage = (int)(0.4 * skillUsed.BasePower) + (int)(0.6 * attacker.Mag) - attacked.End;
            }
            else if (skillUsed.SkillType == BaseAbility.Type.PHYSICAL)
            {
                damage = (int)(0.4 * skillUsed.BasePower) + (int)(0.6 * attacker.Str) - attacked.End;
            }
            damage = damage + (int)Random.Range(-(damage * dmgVarMod), damage * dmgVarMod);
            int randomCrit = Random.Range(0, 100);
            int critChance = (attacker.Acc / 40) + (attacker.Agi / 4);
            if (randomCrit < critChance)
            {
                damage = (int)(damage * 1.2);
            }
            if (damage >= 0)
            {
                totalDamage = damage;
            }
            else
            {
                totalDamage = 0;
            }
        }
        else
        {
            totalDamage = 0;
        }
        return totalDamage;
    }

    //public 
    //private static float dmgMod = 1.5f;
    //private static int totalDmg;

    //public int AttackDamage(BaseCharacter player, BaseCharacter enemy)
    //{
    //    damage = player.Str - enemy.End;
    //    return damage;
    //}

    //public static int PlayerAtkDmg(BaseCharacter characterPlayed)
    //{
    //    totalDmg = (int)(characterPlayed.Str * dmgMod);
    //    Debug.Log("str : " + characterPlayed.Str);
    //    Debug.Log("dmg : " + totalDmg);
    //    totalDmg = totalDmg + (int)Random.Range(-(totalDmg * dmgVarMod), totalDmg * dmgVarMod);
    //    Debug.Log("dmg : " + totalDmg);
    //    return totalDmg;
    //}

    //public static int EnemyAtkDmg(BaseCharacter characterPlayed)
    //{
    //    totalDmg = (int)(characterPlayed.Str * dmgMod);
    //    Debug.Log("str : " + characterPlayed.Str);
    //    Debug.Log("dmg : " + totalDmg);
    //    totalDmg = totalDmg + (int)Random.Range(-(totalDmg * dmgVarMod), totalDmg * dmgVarMod);
    //    Debug.Log("dmg : " + totalDmg);
    //    return totalDmg;
    //}

    //public static int HpReduced(BaseCharacter characterPlayed, int damage)
    //{
    //    return characterPlayed.Hp -= damage;
    //}
}
