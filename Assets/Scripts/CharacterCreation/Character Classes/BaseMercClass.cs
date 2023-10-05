using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMercClass : BaseCharacterClass
{
    public BaseMercClass()
    {
        CharacterClassName = "Merc";
        CharacterClassDescription = "The combat specialist. This Character prefers to use violence to solve their problems.";

        PlayerName = "Renegade";

        MoveLength = 6;

        PlayerActionPoint = 2;

        Unity = 2;

        Understanding = 1;

        Care = 3;

        Autonomy = 1;

        Control = 3;

        Justice = 3;


        //Stress
        Stress = 9;
        NowStress = 9;


        //Convictions
        Conviction = 5;
        NowConviction = 5;

        //Levels
        Pontential = 0;
        NowLevel = 0;

        Life = 9;
        NowLife = 9;

        Athletics = 2;
        Stealth = 3;
        Social = 1;
        Perception = 2;
        ClassExp = 3;
    }
}
