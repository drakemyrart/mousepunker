using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseConnectorClass : BaseCharacterClass
{
    
    public BaseConnectorClass()
    {
        CharacterClassName = "Face";
        CharacterClassDescription = "The face of any party. This Character uses words more then violence to solve their problems.";

        PlayerName = "Steve Slick";
        
        MoveLength = 6;

        PlayerActionPoint = 2;

        Unity = 3;

        Understanding = 3;

        Care = 1;

        Autonomy = 1;

        Control = 3;

        Justice = 3;


        //Stress
        Stress = 9;
        NowStress = Stress;


        //Convictions
        Conviction = 5;
        NowConviction = Conviction;

        //Levels
        Pontential = 0;
        NowLevel = 0;

        Life = 9;
        NowLife = Life;

        Athletics = 2;
        Stealth = 2;
        Social = 4;
        Perception = 2;
        ClassExp = 3;

    }
    
}
