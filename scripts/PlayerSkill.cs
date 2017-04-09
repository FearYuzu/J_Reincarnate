using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour {
    public static int GatheringSkillLevel, ProcessingSkillLevel, FishingSkillLevel, FarmingSkillLevel, CookingSkillLevel, AlchemySkillLevel;
    public static float GatheringSkillExp, ProcessingSkillExp, FishingSkillExp, FarmingSkillExp, CookingSkillExp, AlchemySkillExp;
    //Function
    public static void SkillLevelUp(int SkillNumber)
    {
        switch (SkillNumber) //0=Gathering,1=Processing,2=Fishing,3=Farming,4=Cooking,5=Alchemy;
        {
            case 0:
                GatheringSkillLevel++;
                break;
            case 1:
                ProcessingSkillLevel++;
                break;
            case 2:
                FishingSkillLevel++;
                break;
            case 3:
                FarmingSkillLevel++;
                break;
            case 4:
                CookingSkillLevel++;
                break;
            case 5:
                AlchemySkillLevel++;
                break;
        }
    }
}
