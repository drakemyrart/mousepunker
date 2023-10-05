using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseArketype
{
   

    [Header("Infos")]
    private string playerName;
    private BaseCharacterClass playerClass;
    private int nowLife;
    private int maxLife;
    private int moveLength;
    private int playerActionPoint;

    private Sprite playerPortrait;

   
    [Header("Motivations")]
    private int unity;
    private int understanding;
    private int care;
    private int autonomy;
    private int control;
    private int justice;

    [Header("Stress")]
    private int stress;
    private int nowStress;

    [Header("Conviction")]
    private int conviction;
    private int nowConviction;

    [Header("Expertise")]
    private int motPoints;
    private int expPoints;
    //list of current skills

    [Header("XP")]
    private int potential;
    private int nowLevel;

    private int bonus;

    [Header("Class Ability")]
    private BaseAbility classAbility1;
    private BaseAbility classAbility2;
    private BaseAbility classAbility3;
    private BaseAbility classAbility4;
    private BaseAbility classAbility5;
    private BaseAbility classAbility6;

    //Motivations
    public string PlayerName { get; set; }

    public BaseCharacterClass PlayerClass { get; set; }

    public int MoveLength { get; set; }

    public int PlayerActionPoint { get; set; }

    public Sprite PlayerPortrait { get; set; }


    public int Unity { get; set; }

    public int Understanding { get; set; }

    public int Care { get; set; }

    public int Autonomy { get; set; }

    public int Control { get; set; }

    public int Justice { get; set; }


    //Stress
    public int Stress { get; set; }
    public int NowStress { get; set; }


    //Convictions
    public int Conviction { get; set; }
    public int NowConviction { get; set; }

    //Levels
    public int Pontential { get; set; }
    public int NowLevel { get; set; }

    public int Life { get; set; }
    public int NowLife { get; set; }

    public int Bonus { get; set; }

    //Ability
    public BaseAbility ClassAbility1 { get; set; }
    public BaseAbility ClassAbility2 { get; set; }
    public BaseAbility ClassAbility3 { get; set; }
    public BaseAbility ClassAbility4 { get; set; }
    public BaseAbility ClassAbility5 { get; set; }
    public BaseAbility ClassAbility6 { get; set; }

    private int perception;
    private int stealth;
    private int atheltics;
    private int social;
    private int classExp;

    private BaseAbility athleticsAbility1;
    private BaseAbility athleticsAbility2;
    private BaseAbility athleticsAbility4;
    private BaseAbility athleticsAbility5;
    private BaseAbility athleticsAbility6;

    private BaseAbility stealthAbility1;
    private BaseAbility stealthAbility2;
    private BaseAbility stealthAbility3;
    private BaseAbility stealthAbility4;
    private BaseAbility stealthAbility5;
    private BaseAbility stealthAbility6;

    public string CharacterClassName { get; set; }
    public string CharacterClassDescription { get; set; }
    public int Perception { get; set; }
    public int Stealth { get; set; }
    public int Athletics { get; set; }
    public int Social { get; set; }
    public int ClassExp { get; set; }

    public BaseAbility AthleticsAbility1 { get; set; }
    public BaseAbility AthleticsAbility2 { get; set; }
    public BaseAbility AthleticsAbility3 { get; set; }
    public BaseAbility AthleticsAbility4 { get; set; }
    public BaseAbility AthleticsAbility5 { get; set; }
    public BaseAbility AthleticsAbility6 { get; set; }

    public BaseAbility StealthAbility1 { get; set; }
    public BaseAbility StealthAbility2 { get; set; }
    public BaseAbility StealthAbility3 { get; set; }
    public BaseAbility StealthAbility4 { get; set; }
    public BaseAbility StealthAbility5 { get; set; }
    public BaseAbility StealthAbility6 { get; set; }
}

