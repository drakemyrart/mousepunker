using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class DiceRoller : MonoBehaviour
{
    static DiceRoller instance;

    public  int[] RollResult = new int[2];

    private void Start()
    {
        instance = this;
    }

    public void Roll(int exp, int mot)
    {
              
        if (exp == 1)
        {
            RollResult[1] = Random.Range(1, 4);
            
        }
        else if (exp == 2)
        {
            RollResult[0] = Random.Range(1, 6);
            
        }
        else if (exp == 3)
        {
            RollResult[0] = Random.Range(1, 8);
            
        }
        else if (exp == 4)
        {
            RollResult[0] = Random.Range(1, 10);
            
        }
        else if (exp == 5)
        {
            RollResult[0] = Random.Range(1, 12);
           
        }

        if (mot == 1)
        {
            RollResult[1] = Random.Range(1, 4);

        }
        else if (mot == 2)
        {
            RollResult[1] = Random.Range(1, 6);

        }
        else if (mot == 3)
        {
            RollResult[1] = Random.Range(1, 8);

        }
        else if (mot == 4)
        {
            RollResult[1] = Random.Range(1, 10);

        }
        else if (mot == 5)
        {
            RollResult[1] = Random.Range(1, 12);

        }

    }
}
