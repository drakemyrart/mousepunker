using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AthleticsAttackAbility : BaseAbility
{
    public AthleticsAttackAbility()
    {
        AbilityName = "Basic Attack";
        AbilityDescription = "Your basic attack move";
        AbilityID = (int)AbilityIDnr.Attack;
        AbilityPower = 1;
        AbilityCost = 10;
        AbilityTargetStat = (int)AbilityTargetnr.Life;
    }
}
