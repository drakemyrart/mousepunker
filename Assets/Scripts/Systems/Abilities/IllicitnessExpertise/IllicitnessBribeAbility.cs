using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IllicitnessBribeAbility : BaseAbility
{
    public IllicitnessBribeAbility()
    {
        AbilityName = "Bribe";
        AbilityDescription = "Bribe them to go away";
        AbilityID = (int)AbilityIDnr.Voice;
        AbilityPower = 1;
        AbilityCost = 10;
        AbilityTargetStat = (int)AbilityTargetnr.Conviction;
    }
}
