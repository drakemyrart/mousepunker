using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IllicitnessPrimeAbility : BaseAbility
{
    public IllicitnessPrimeAbility()
    {
        AbilityName = "Prime";
        AbilityDescription = "Your basic attack move";
        AbilityID = (int)AbilityIDnr.Attack;
        AbilityPower = 2;
        AbilityCost = 10;
        AbilityTargetStat = (int)AbilityTargetnr.Conviction;
    }
}
