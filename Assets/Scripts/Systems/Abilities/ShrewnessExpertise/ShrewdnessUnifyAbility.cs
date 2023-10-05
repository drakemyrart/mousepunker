using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrewdnessUnifyAbility : BaseAbility
{
    public ShrewdnessUnifyAbility()
    {
        AbilityName = "Unify";
        AbilityDescription = "Your basic attack move";
        AbilityID = (int)AbilityIDnr.Support;
        AbilityPower = 4;
        AbilityCost = 10;
        AbilityTargetStat = (int)AbilityTargetnr.Conviction;
    }
}
