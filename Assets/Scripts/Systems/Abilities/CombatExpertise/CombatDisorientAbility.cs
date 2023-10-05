using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatDisorientAbility : BaseAbility
{
    public CombatDisorientAbility()
    {
        AbilityName = "Disorient";
        AbilityDescription = "Your basic attack move";
        AbilityID = (int)AbilityIDnr.Aggitation;
        AbilityPower = 10;
        AbilityCost = 10;
        AbilityTargetStat = (int)AbilityTargetnr.Stress;
    }
}
