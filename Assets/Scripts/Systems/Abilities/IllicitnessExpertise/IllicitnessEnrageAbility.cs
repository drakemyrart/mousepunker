using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IllicitnessEnrageAbility : BaseAbility
{
    public IllicitnessEnrageAbility()
    {
        AbilityName = "Enrage";
        AbilityDescription = "Your basic attack move";
        AbilityID = (int)AbilityIDnr.Attack;
        AbilityPower = 4;
        AbilityCost = 10;
        AbilityTargetStat = (int)AbilityTargetnr.Stress;
    }
}
