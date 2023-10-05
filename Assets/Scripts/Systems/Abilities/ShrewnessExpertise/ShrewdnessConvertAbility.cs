using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrewdnessConvertAbility : BaseAbility
{
    public ShrewdnessConvertAbility()
    {
        AbilityName = "Convert";
        AbilityDescription = "Your basic attack move";
        AbilityID = (int)AbilityIDnr.Voice;
        AbilityPower = 1;
        AbilityCost = 10;
        AbilityTargetStat = (int)AbilityTargetnr.All;
    }
}
