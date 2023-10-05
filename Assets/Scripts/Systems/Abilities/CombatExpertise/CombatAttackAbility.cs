using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatAttackAbility : BaseAbility
{
    public CombatAttackAbility()
    {
        AbilityName = "Attack";
        AbilityDescription = "Your basic attack move";
        AbilityID = (int)AbilityIDnr.Attack;
        AbilityPower = 5;
        AbilityCost = 10;
        AbilityTargetStat = (int)AbilityTargetnr.Life;
    }
}
