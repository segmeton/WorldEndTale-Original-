using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GrowthCalculation
{
    public BaseCharacter GrowCharacter(BaseCharacter character, int exp)
    {
        
        character.CurrentXp += exp;
        do
        {
            if (character.CurrentXp >= character.XpToLvUp)
            {
                int regXp;
                character.CurrentXp -= character.XpToLvUp;
                character.Lv++;
                GameInformation.expTable[character.Lv - 1].TryGetValue("ExpRequired", out regXp);
                character.XpToLvUp = regXp;
                character.Hp += character.HpGrowth;
                character.Mp += character.MpGrowth;
                character.CurrentHp += character.HpGrowth;
                character.CurrentMp += character.MpGrowth;
                //character.Str += character.StrGrowth;
                //character.Agi += character.AgiGrowth;
                //character.Mag += character.MagGrowth;
                //character.End += character.EndGrowth;
                //character.Acc += character.AccGrowth;
            }
        } while (character.CurrentXp >= character.XpToLvUp);
        character.Str = character.BaseStr + (character.Lv - 1) * character.StrGrowth + character.BaseStr;
        character.Agi = character.BaseAgi + (character.Lv - 1) * character.AgiGrowth + character.BaseAgi;
        character.End = character.BaseEnd + (character.Lv - 1) * character.EndGrowth + character.BaseEnd;
        character.Mag = character.BaseMag + (character.Lv - 1) * character.MagGrowth + character.BaseMag;
        character.Acc = character.BaseAcc + (character.Lv - 1) * character.AccGrowth + character.BaseAcc;
        return character;
    }
}
