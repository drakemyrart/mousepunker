using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatProtectAbility : BaseAbility
{
    public CombatProtectAbility()
    {
        AbilityName = "Heal";
        AbilityDescription = "Your basic attack move";
        AbilityID = (int)AbilityIDnr.Support;
        AbilityPower = 3;
        AbilityCost = 10;
        AbilityTargetStat = (int)AbilityTargetnr.Life;
    }
}
