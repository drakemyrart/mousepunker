using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IllicitnessExtortAbility : BaseAbility
{
    public IllicitnessExtortAbility()
    {
        AbilityName = "Extort";
        AbilityDescription = "Your basic attack move";
        AbilityID = (int)AbilityIDnr.Voice;
        AbilityPower = 1;
        AbilityCost = 10;
        AbilityTargetStat = (int)AbilityTargetnr.Stress;
    }
}
