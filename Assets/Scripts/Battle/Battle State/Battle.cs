using UnityEngine;
using System.Collections;

public class Battle
{
    private bool isPlayerTurn;
    private BaseCharacter.CharacterUnit turnOwner;
    private DamageCalculation damageCalculation = new DamageCalculation();

    public bool IsPlayerTurn
    {
        set { isPlayerTurn = value; }
        get { return isPlayerTurn; }
    }
    public void BattlePhase()
    {
        //Debug.Log("enemy : "+BattleInformation.Enemy.Length);
        isPlayerTurn = BattleInformation.playerTurn;
        increaseATB();
        EnemyTurn();
        ResetATB();
    }

    private void increaseATB()
    {
        float currentAtb;
        float cecilAtbIncrement;
        float limcaAtbIncrement;
        float galardAtbIncrement;
        float enemy01AtbIncrement;
        float enemy02AtbIncrement;
        float enemy03AtbIncrement;
        //float cecilAtbIncrement = GetIncrement(80);
        //float limcaAtbIncrement = GetIncrement(90);
        //float galardAtbIncrement = GetIncrement(100);
        //float enemy01AtbIncrement = GetIncrement(100);
        //float enemy02AtbIncrement = GetIncrement(80);
        //float enemy03AtbIncrement = GetIncrement(50);
        
        if (isPlayerTurn == false)
        {
            //Debug.Log("increaseATB : " + isPlayerTurn);
            if (BattleInformation.Cecil.CurrentHp > 0)
            {
                cecilAtbIncrement = GetIncrement(BattleInformation.Cecil.Agi);
                //cecilAtbIncrement = GetIncrement(150);
                currentAtb = BattleInformation.cecilAtb;
                currentAtb += cecilAtbIncrement;
                if (currentAtb > 300)
                {
                    currentAtb = 300;
                }
                BattleInformation.cecilAtb = currentAtb;
                if (BattleInformation.cecilAtb == 300)
                {
                    BattleInformation.playerTurn = true;
                }
            }
            if (BattleInformation.Limca.CurrentHp > 0)
            {
                limcaAtbIncrement = GetIncrement(BattleInformation.Limca.Agi);
                //limcaAtbIncrement = GetIncrement(150);
                currentAtb = BattleInformation.limcaAtb;
                currentAtb += limcaAtbIncrement;
                if (currentAtb > 300)
                {
                    currentAtb = 300;
                }
                BattleInformation.limcaAtb = currentAtb;
                if (BattleInformation.limcaAtb == 300)
                {
                    BattleInformation.playerTurn = true;
                }
            }
            if (BattleInformation.Galard.CurrentHp > 0)
            {
                galardAtbIncrement = GetIncrement(BattleInformation.Galard.Agi);
                currentAtb = BattleInformation.galardAtb;
                currentAtb += galardAtbIncrement;
                if (currentAtb > 300)
                {
                    currentAtb = 300;
                }
                BattleInformation.galardAtb = currentAtb;
                if (BattleInformation.galardAtb == 300)
                {
                    BattleInformation.playerTurn = true;
                }
            }
            if (BattleInformation.Enemy[0] != null)
            {
                if (BattleInformation.Enemy[0].CurrentHp > 0)
                {
                    enemy01AtbIncrement = GetIncrement(BattleInformation.Enemy[0].Agi);
                    //enemy01AtbIncrement = GetIncrement(100);
                    currentAtb = BattleInformation.enemy01Atb;
                    currentAtb += enemy01AtbIncrement;
                    if (currentAtb > 300)
                    {
                        currentAtb = 300;
                    }
                    BattleInformation.enemy01Atb = currentAtb;
                }        
            }
            if (BattleInformation.Enemy[1] != null)
            {
                if (BattleInformation.Enemy[1].CurrentHp > 0)
                {
                    enemy02AtbIncrement = GetIncrement(BattleInformation.Enemy[1].Agi);
                    //enemy02AtbIncrement = GetIncrement(80);
                    currentAtb = BattleInformation.enemy02Atb;
                    currentAtb += enemy02AtbIncrement;
                    if (currentAtb > 300)
                    {
                        currentAtb = 300;
                    }
                    BattleInformation.enemy02Atb = currentAtb;
                }
            }
            if (BattleInformation.Enemy[2] != null)
            {
                if (BattleInformation.Enemy[2].CurrentHp > 0)
                {
                    enemy03AtbIncrement = GetIncrement(BattleInformation.Enemy[2].Agi);
                    //enemy03AtbIncrement = GetIncrement(90);
                    currentAtb = BattleInformation.enemy03Atb;
                    currentAtb += enemy03AtbIncrement;
                    if (currentAtb > 300)
                    {
                        currentAtb = 300;
                    }
                    BattleInformation.enemy03Atb = currentAtb;
                }
            }
        }


    }

    private float GetIncrement(int agi)
    {
        //float increment = (float)(0.15 * agi / 16);
        //Debug.Log(increment);
        float increment = (float)(BattleInformation.maxAtbValue * 154) / (float)((-15 * agi + 3200) * 20);
        //Debug.Log(increment);
        return increment;
    }

    private void EnemyTurn()
    {
        if (BattleInformation.Enemy[0] != null)
        {
            if (BattleInformation.Enemy[0].CurrentHp > 0)
            {
                if (BattleInformation.enemy01Atb == 300)
                {
                    int mpReducer = 0;
                    if (BattleInformation.Enemy[0].AbilityList.Count == 0)
                    {
                        AttackPlayer(BattleInformation.Enemy[0]);
                    }
                    else if (BattleInformation.Enemy[0].AbilityList.Count != 0)
                    {
                        //Debug.Log("have skill");
                        int random = Random.Range(0, 100);
                        int skillSelected;
                        int count;
                        if (BattleInformation.Enemy[0].Lv > 7)
                        { 
                            if (random > 50)
                            {
                                count = BattleInformation.Enemy[0].AbilityList.Count;
                                skillSelected = Random.Range(0, count);
                                if (BattleInformation.Enemy[0].CurrentMp >= BattleInformation.Enemy[0].AbilityList[skillSelected].MpCost)
                                {
                                    if (BattleInformation.Enemy[0].AbilityList[skillSelected].TargetEnemy == BaseAbility.Target.SINGLE)
                                    {
                                        SkillDamageToPlayer(BattleInformation.Enemy[0], BattleInformation.Enemy[0].AbilityList[skillSelected]);
                                    }
                                    else if (BattleInformation.Enemy[0].AbilityList[skillSelected].TargetEnemy == BaseAbility.Target.ALL)
                                    {
                                        SkillDamageToAllPlayer(BattleInformation.Enemy[0], BattleInformation.Enemy[0].AbilityList[skillSelected]);
                                    }
                                    BattleInformation.Enemy[0].CurrentMp -= mpReducer;
                                }
                                else 
                                {
                                    AttackPlayer(BattleInformation.Enemy[0]);
                                }
                            }
                            else 
                            {
                                AttackPlayer(BattleInformation.Enemy[0]);
                            }
                        }
                        else if (BattleInformation.Enemy[0].Lv > 3)
                        {
                            count = BattleInformation.Enemy[0].AbilityList.Count;
                            skillSelected = Random.Range(0, count);
                            if (BattleInformation.Enemy[0].CurrentMp >= BattleInformation.Enemy[0].AbilityList[skillSelected].MpCost)
                            {
                                if (BattleInformation.Enemy[0].AbilityList[skillSelected].TargetEnemy == BaseAbility.Target.SINGLE)
                                {
                                    SkillDamageToPlayer(BattleInformation.Enemy[0], BattleInformation.Enemy[0].AbilityList[skillSelected]);
                                }
                                else if (BattleInformation.Enemy[0].AbilityList[skillSelected].TargetEnemy == BaseAbility.Target.ALL)
                                {
                                    SkillDamageToAllPlayer(BattleInformation.Enemy[0], BattleInformation.Enemy[0].AbilityList[skillSelected]);
                                }
                                BattleInformation.Enemy[0].CurrentMp -= mpReducer;
                            }
                            else
                            {
                                AttackPlayer(BattleInformation.Enemy[0]);
                            }
                        }
                        else 
                        {
                            //Debug.Log("low lv");
                            if (random > 75)
                            {
                                count = BattleInformation.Enemy[0].AbilityList.Count;
                                skillSelected = Random.Range(0, count);
                                if (BattleInformation.Enemy[0].CurrentMp >= BattleInformation.Enemy[0].AbilityList[skillSelected].MpCost)
                                {
                                    if (BattleInformation.Enemy[0].AbilityList[skillSelected].TargetEnemy == BaseAbility.Target.SINGLE)
                                    {
                                        SkillDamageToPlayer(BattleInformation.Enemy[0], BattleInformation.Enemy[0].AbilityList[skillSelected]);
                                    }
                                    else if (BattleInformation.Enemy[0].AbilityList[skillSelected].TargetEnemy == BaseAbility.Target.ALL)
                                    {
                                        SkillDamageToAllPlayer(BattleInformation.Enemy[0], BattleInformation.Enemy[0].AbilityList[skillSelected]);
                                    }
                                    BattleInformation.Enemy[0].CurrentMp -= mpReducer;
                                }
                                else
                                {
                                    AttackPlayer(BattleInformation.Enemy[0]);
                                }
                            }
                            else
                            {
                                //Debug.Log("dont use skill");
                                AttackPlayer(BattleInformation.Enemy[0]);
                            }
                        }
                    }
                    //Debug.Log("damage : "+damage);
                    BattleInformation.enemy01Atb = 0;
                }
            }
        }
        if (BattleInformation.Enemy[1] != null)
        {
            if (BattleInformation.Enemy[1].CurrentHp > 0)
            {
                //Debug.Log("check hp");
                if (BattleInformation.enemy02Atb == 300)
                {
                    int mpReducer = 0;
                    if (BattleInformation.Enemy[1].AbilityList.Count == 0)
                    {
                        AttackPlayer(BattleInformation.Enemy[1]);
                    }
                    else if (BattleInformation.Enemy[1].AbilityList.Count != 0)
                    {
                        //Debug.Log("have skill");
                        int random = Random.Range(0, 100);
                        int skillSelected;
                        int count;
                        if (BattleInformation.Enemy[1].Lv > 7)
                        {
                            if (random > 50)
                            {
                                count = BattleInformation.Enemy[1].AbilityList.Count;
                                skillSelected = Random.Range(0, count);
                                if (BattleInformation.Enemy[1].CurrentMp >= BattleInformation.Enemy[1].AbilityList[skillSelected].MpCost)
                                {
                                    if (BattleInformation.Enemy[1].AbilityList[skillSelected].TargetEnemy == BaseAbility.Target.SINGLE)
                                    {
                                        SkillDamageToPlayer(BattleInformation.Enemy[1], BattleInformation.Enemy[1].AbilityList[skillSelected]);
                                    }
                                    else if (BattleInformation.Enemy[1].AbilityList[skillSelected].TargetEnemy == BaseAbility.Target.ALL)
                                    {
                                        SkillDamageToAllPlayer(BattleInformation.Enemy[1], BattleInformation.Enemy[1].AbilityList[skillSelected]);
                                    }
                                    BattleInformation.Enemy[1].CurrentMp -= mpReducer;
                                }
                                else
                                {
                                    AttackPlayer(BattleInformation.Enemy[1]);
                                }
                            }
                            else
                            {
                                AttackPlayer(BattleInformation.Enemy[1]);
                            }
                        }
                        else if (BattleInformation.Enemy[1].Lv > 3)
                        {
                            count = BattleInformation.Enemy[1].AbilityList.Count;
                            skillSelected = Random.Range(0, count);
                            if (BattleInformation.Enemy[1].CurrentMp >= BattleInformation.Enemy[1].AbilityList[skillSelected].MpCost)
                            {
                                if (BattleInformation.Enemy[1].AbilityList[skillSelected].TargetEnemy == BaseAbility.Target.SINGLE)
                                {
                                    SkillDamageToPlayer(BattleInformation.Enemy[1], BattleInformation.Enemy[1].AbilityList[skillSelected]);
                                }
                                else if (BattleInformation.Enemy[1].AbilityList[skillSelected].TargetEnemy == BaseAbility.Target.ALL)
                                {
                                    SkillDamageToAllPlayer(BattleInformation.Enemy[1], BattleInformation.Enemy[1].AbilityList[skillSelected]);
                                }
                                BattleInformation.Enemy[1].CurrentMp -= mpReducer;
                            }
                            else
                            {
                                AttackPlayer(BattleInformation.Enemy[1]);
                            }
                        }
                        else
                        {
                            //Debug.Log("low lv");
                            if (random > 75)
                            {
                                count = BattleInformation.Enemy[1].AbilityList.Count;
                                skillSelected = Random.Range(0, count);
                                if (BattleInformation.Enemy[1].CurrentMp >= BattleInformation.Enemy[1].AbilityList[skillSelected].MpCost)
                                {
                                    if (BattleInformation.Enemy[1].AbilityList[skillSelected].TargetEnemy == BaseAbility.Target.SINGLE)
                                    {
                                        SkillDamageToPlayer(BattleInformation.Enemy[1], BattleInformation.Enemy[1].AbilityList[skillSelected]);
                                    }
                                    else if (BattleInformation.Enemy[1].AbilityList[skillSelected].TargetEnemy == BaseAbility.Target.ALL)
                                    {
                                        SkillDamageToAllPlayer(BattleInformation.Enemy[1], BattleInformation.Enemy[1].AbilityList[skillSelected]);
                                    }
                                    BattleInformation.Enemy[1].CurrentMp -= mpReducer;
                                }
                                else
                                {
                                    AttackPlayer(BattleInformation.Enemy[1]);
                                }
                            }
                            else
                            {
                                //Debug.Log("dont use skill");
                                AttackPlayer(BattleInformation.Enemy[1]);
                            }
                        }
                    }
                    //Debug.Log("damage : "+damage);
                    BattleInformation.enemy02Atb = 0;
                }
            }
        }
        if (BattleInformation.Enemy[2] != null)
        {
            if (BattleInformation.Enemy[2].CurrentHp > 0)
            {
                //Debug.Log("check hp");
                if (BattleInformation.enemy03Atb == 300)
                {
                    //Debug.Log("check atb");
                    int mpReducer = 0;
                    if (BattleInformation.Enemy[2].AbilityList.Count == 0)
                    {
                        AttackPlayer(BattleInformation.Enemy[2]);
                    }
                    else if (BattleInformation.Enemy[2].AbilityList.Count != 0)
                    {
                        //Debug.Log("have skill");
                        int random = Random.Range(0, 100);
                        int skillSelected;
                        int count;
                        if (BattleInformation.Enemy[2].Lv > 7)
                        {
                            if (random > 50)
                            {
                                count = BattleInformation.Enemy[2].AbilityList.Count;
                                skillSelected = Random.Range(0, count);
                                if (BattleInformation.Enemy[2].CurrentMp >= BattleInformation.Enemy[2].AbilityList[skillSelected].MpCost)
                                {
                                    if (BattleInformation.Enemy[2].AbilityList[skillSelected].TargetEnemy == BaseAbility.Target.SINGLE)
                                    {
                                        SkillDamageToPlayer(BattleInformation.Enemy[2], BattleInformation.Enemy[2].AbilityList[skillSelected]);
                                    }
                                    else if (BattleInformation.Enemy[2].AbilityList[skillSelected].TargetEnemy == BaseAbility.Target.ALL)
                                    {
                                        SkillDamageToAllPlayer(BattleInformation.Enemy[2], BattleInformation.Enemy[2].AbilityList[skillSelected]);
                                    }
                                    BattleInformation.Enemy[2].CurrentMp -= mpReducer;
                                }
                                else
                                {
                                    AttackPlayer(BattleInformation.Enemy[2]);
                                }
                            }
                            else
                            {
                                AttackPlayer(BattleInformation.Enemy[2]);
                            }
                        }
                        else if (BattleInformation.Enemy[2].Lv > 3)
                        {
                            count = BattleInformation.Enemy[2].AbilityList.Count;
                            skillSelected = Random.Range(0, count);
                            if (BattleInformation.Enemy[2].CurrentMp >= BattleInformation.Enemy[2].AbilityList[skillSelected].MpCost)
                            {
                                if (BattleInformation.Enemy[2].AbilityList[skillSelected].TargetEnemy == BaseAbility.Target.SINGLE)
                                {
                                    SkillDamageToPlayer(BattleInformation.Enemy[2], BattleInformation.Enemy[2].AbilityList[skillSelected]);
                                }
                                else if (BattleInformation.Enemy[2].AbilityList[skillSelected].TargetEnemy == BaseAbility.Target.ALL)
                                {
                                    SkillDamageToAllPlayer(BattleInformation.Enemy[2], BattleInformation.Enemy[2].AbilityList[skillSelected]);
                                }
                                BattleInformation.Enemy[2].CurrentMp -= mpReducer;
                            }
                            else
                            {
                                AttackPlayer(BattleInformation.Enemy[2]);
                            }
                        }
                        else
                        {
                            //Debug.Log("low lv");
                            if (random > 75)
                            {
                                count = BattleInformation.Enemy[2].AbilityList.Count;
                                skillSelected = Random.Range(0, count);
                                if (BattleInformation.Enemy[2].CurrentMp >= BattleInformation.Enemy[2].AbilityList[skillSelected].MpCost)
                                {
                                    if (BattleInformation.Enemy[2].AbilityList[skillSelected].TargetEnemy == BaseAbility.Target.SINGLE)
                                    {
                                        SkillDamageToPlayer(BattleInformation.Enemy[2], BattleInformation.Enemy[2].AbilityList[skillSelected]);
                                    }
                                    else if (BattleInformation.Enemy[2].AbilityList[skillSelected].TargetEnemy == BaseAbility.Target.ALL)
                                    {
                                        SkillDamageToAllPlayer(BattleInformation.Enemy[2], BattleInformation.Enemy[2].AbilityList[skillSelected]);
                                    }
                                    BattleInformation.Enemy[2].CurrentMp -= mpReducer;
                                }
                                else
                                {
                                    AttackPlayer(BattleInformation.Enemy[2]);
                                }
                            }
                            else
                            {
                                //Debug.Log("dont use skill");
                                AttackPlayer(BattleInformation.Enemy[2]);
                            }
                        }
                    }
                    //Debug.Log("damage : "+damage);
                    BattleInformation.enemy03Atb = 0;
                }
            }
        }
    }

    private void AttackPlayer(BaseEnemy enemy)
    {
        BaseCharacter character = GetCharacterTarget();
        int damage = damageCalculation.AttackDamage(enemy, character);
        ReducePlayerHP(character, damage);
    }

    private void SkillDamageToPlayer(BaseEnemy enemy, BaseAbility ability)
    {
        BaseCharacter character = GetCharacterTarget();
        int damage = damageCalculation.EnemySkillDamage(enemy, character, ability);
        ReducePlayerHP(character, damage);
    }

    private void SkillDamageToAllPlayer(BaseEnemy enemy, BaseAbility ability)
    {
        int damage;
        
        damage = damageCalculation.EnemySkillDamage(enemy, BattleInformation.Cecil, ability);
        BattleInformation.Cecil.CurrentHp -= damage;
        if (BattleInformation.Cecil.CurrentHp < 0) BattleInformation.Cecil.CurrentHp = 0;
        
        damage = damageCalculation.EnemySkillDamage(enemy, BattleInformation.Limca, ability);
        BattleInformation.Limca.CurrentHp -= damage;
        if (BattleInformation.Limca.CurrentHp < 0) BattleInformation.Limca.CurrentHp = 0;
        
        damage = damageCalculation.EnemySkillDamage(enemy, BattleInformation.Galard, ability);
        BattleInformation.Galard.CurrentHp -= damage;
        if (BattleInformation.Cecil.CurrentHp < 0) BattleInformation.Galard.CurrentHp = 0;
    }

    private void ReducePlayerHP(BaseCharacter character, int damage)
    {
        switch (character.CharacterUnitName)
        {
            case (BaseCharacter.CharacterUnit.CECIL):
                BattleInformation.Cecil.CurrentHp -= damage;
                if (BattleInformation.Cecil.CurrentHp < 0) BattleInformation.Cecil.CurrentHp = 0;
                break;
            case (BaseCharacter.CharacterUnit.LIMCA):
                BattleInformation.Limca.CurrentHp -= damage;
                if (BattleInformation.Limca.CurrentHp < 0) BattleInformation.Limca.CurrentHp = 0;
                break;
            case (BaseCharacter.CharacterUnit.GALARD):
                BattleInformation.Galard.CurrentHp -= damage;
                if (BattleInformation.Galard.CurrentHp < 0) BattleInformation.Galard.CurrentHp = 0;
                break;
        }
    }

    private BaseCharacter GetCharacterTarget()
    {
        BaseCharacter character = new BaseCharacter();
        do 
        {
            int random = Random.Range(0, 3);
            if (random == 0)
            {
                character = BattleInformation.Cecil;
            }
            else if (random == 1)
            {
                character = BattleInformation.Limca;
            }
            else if (random == 2)
            {
                character = BattleInformation.Galard;
            }
        } 
        while (character.CurrentHp == 0);
        return character;
    }

    private void ResetATB()
    {
        if (BattleInformation.Cecil.CurrentHp == 0) BattleInformation.cecilAtb = 0;
        if (BattleInformation.Limca.CurrentHp == 0) BattleInformation.limcaAtb = 0;
        if (BattleInformation.Galard.CurrentHp == 0) BattleInformation.galardAtb = 0;
        if (BattleInformation.Enemy[0] != null)
        {
            if (BattleInformation.Enemy[0].CurrentHp == 0) BattleInformation.enemy01Atb = 0;
        }
        if (BattleInformation.Enemy[1] != null)
        {
            if (BattleInformation.Enemy[1].CurrentHp == 0) BattleInformation.enemy02Atb = 0;
        }
        if (BattleInformation.Enemy[2] != null)
        {
            if (BattleInformation.Enemy[2].CurrentHp == 0) BattleInformation.enemy03Atb = 0;
        }
    }
}
