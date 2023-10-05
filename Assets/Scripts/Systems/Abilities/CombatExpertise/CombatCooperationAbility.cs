using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatCooperationAbility : BaseAbility
{
    public CombatCooperationAbility()
    {
        AbilityName = "Cooperation";
        AbilityDescription = "Your basic attack move";
        AbilityID = (int)AbilityIDnr.Support;
        AbilityPower = 10;
        AbilityCost = 10;
        AbilityTargetStat = (int)AbilityTargetnr.Bonus;
    }
}
