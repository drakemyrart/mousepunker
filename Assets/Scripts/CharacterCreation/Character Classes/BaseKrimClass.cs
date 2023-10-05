using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseKrimClass : BaseCharacterClass
{
   
    public BaseKrimClass()
    {
        CharacterClassName = "Ganger";
        CharacterClassDescription = "A ganger without a gang. This character prefers to do what suits them.";

        PlayerName = "Mocking Pauli";

        MoveLength = 6;

        PlayerActionPoint = 2;

        Unity = 2;

        Understanding = 1;

        Care = 1;

        Autonomy = 3;

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
        Stealth = 3;
        Social = 1;
        Perception = 2;
        ClassExp = 3;
    }
}
