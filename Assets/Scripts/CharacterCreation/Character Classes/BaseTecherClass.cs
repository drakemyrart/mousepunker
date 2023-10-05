using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTecherClass : BaseCharacterClass
{
    private int tech;

    public int Tech { get; set; }

    public void TecherClass()
    {
        CharacterClassName = "Techer";
        CharacterClassDescription = "Fixerand destroyer of things.";
    }
}
