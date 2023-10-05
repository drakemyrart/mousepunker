using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AthleticsRescueAbility : BaseAbility
{
    public AthleticsRescueAbility()
    {
        AbilityName = "Basic Attack";
        AbilityDescription = "Your basic attack move";
        AbilityID = (int)AbilityIDnr.Attack;
        AbilityPower = 10;
        AbilityCost = 10;
        AbilityTargetStat = (int)AbilityTargetnr.Life;
    }
}
