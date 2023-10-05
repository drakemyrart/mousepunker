using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IllicitnessStealAbility : BaseAbility
{
    public IllicitnessStealAbility()
    {
        AbilityName = "Attack";
        AbilityDescription = "Your basic attack move";
        AbilityID = (int)AbilityIDnr.Attack;
        AbilityPower = 3;
        AbilityCost = 10;
        AbilityTargetStat = (int)AbilityTargetnr.Life;
    }
}
