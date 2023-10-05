using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatCeasefireAbility : BaseAbility
{
    public CombatCeasefireAbility()
    {
        AbilityName = "Cease Fire";
        AbilityDescription = "Your basic attack move";
        AbilityID = (int)AbilityIDnr.Voice;
        AbilityPower = 1;
        AbilityCost = 10;
        AbilityTargetStat = (int)AbilityTargetnr.Stress;
    }
}
