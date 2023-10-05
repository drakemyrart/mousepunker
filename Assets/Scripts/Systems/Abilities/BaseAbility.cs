using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseAbility
{
    private string abilityName;
    private string abilityDescription;
    private int abilityID;
    private int abilityPower;
    private int abilityCost;
    private int abilityTargetStat;
    private int abilityTargetType;
    private int abilityExpertise;
    private int abilityMotivation;
    private int abilityExpertiseAmount;
    private int abilityMotivationAmount;


    public string AbilityName { get; set; }
    public string AbilityDescription { get; set; }
    public int AbilityID { get; set; }
    public int AbilityPower { get; set; }
    public int AbilityCost { get; set; }
    public int AbilityTargetStat { get; set; }
    public int AbilityTargetType { get; set; }
    public int AbilityExpertise { get; set; }
    public int AbilityMotivation { get; set; }
    public int AbilityExpertiseAmount { get; set; }
    public int AbilityMotivationAmount { get; set; }
}
