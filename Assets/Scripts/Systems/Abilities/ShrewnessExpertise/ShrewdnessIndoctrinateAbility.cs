using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrewdnessIndoctrinateAbility : BaseAbility
{
    public ShrewdnessIndoctrinateAbility()
    {
        AbilityName = "Indoctrinate";
        AbilityDescription = "Your basic attack move";
        AbilityID = (int)AbilityIDnr.Attack;
        AbilityPower = 3;
        AbilityCost = 10;
        AbilityTargetStat = (int)AbilityTargetnr.Conviction;
    }
}
