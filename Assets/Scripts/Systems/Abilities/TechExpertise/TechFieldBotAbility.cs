using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechFieldBotAbility : BaseAbility
{
    public TechFieldBotAbility()
    {
        AbilityName = "Basic Attack";
        AbilityDescription = "Your basic attack move";
        AbilityID = (int)AbilityIDnr.Attack;
        AbilityPower = 10;
        AbilityCost = 10;
        AbilityTargetStat = (int)AbilityTargetnr.Life;
    }
}
