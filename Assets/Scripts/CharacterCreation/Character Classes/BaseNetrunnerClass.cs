using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseNetrunnerClass : BaseCharacterClass
{
    private int interfacing;

    public int Interfacing { get; set; }

    public void NetrunnerClass()
    {
        CharacterClassName = "Netrunner";
        CharacterClassDescription = "The black hats of the SpederNet";
    }
}
