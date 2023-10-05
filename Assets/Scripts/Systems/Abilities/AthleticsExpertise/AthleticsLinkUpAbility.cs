using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AthleticsLinkUpAbility : BaseAbility
{
    public AthleticsLinkUpAbility()
    {
        AbilityName = "Basic Attack";
        AbilityDescription = "Your basic attack move";
        AbilityID = (int)AbilityIDnr.Attack;
        AbilityPower = 10;
        AbilityCost = 10;
        AbilityTargetStat = (int)AbilityTargetnr.Life;
    }
}
