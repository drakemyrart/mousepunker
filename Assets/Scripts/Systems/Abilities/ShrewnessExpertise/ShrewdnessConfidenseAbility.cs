using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrewdnessConfidenseAbility : BaseAbility
{
    public ShrewdnessConfidenseAbility()
    {
        AbilityName = "Confidense";
        AbilityDescription = "Your basic attack move";
        AbilityID = (int)AbilityIDnr.Support;
        AbilityPower = 3;
        AbilityCost = 10;
        AbilityTargetStat = (int)AbilityTargetnr.Stress;
    }
}
