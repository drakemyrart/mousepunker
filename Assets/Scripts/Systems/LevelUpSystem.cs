using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpSystem : MonoBehaviour {

    public int currentLevel;
    public int baseXP = 20;
    public int currentXP;

    public int xpForNextLevel;
    public int xpDifferencetoNextLevel;
    public int totalXpDifference;

    public float fillAmount;
    public float reverseFillAmout;

    public int xpPotential;


	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   public void AddXp()
    {
        CalculateLevel(5);
    }

    void CalculateLevel (int amount)
    {
        currentXP += amount;

        int tempCurLevel = (int)Mathf.Sqrt(currentXP / baseXP)+1;

        if(currentLevel != tempCurLevel)
        {
            currentLevel = tempCurLevel;
        }

        xpForNextLevel = baseXP * (currentLevel) * (currentLevel);
        xpDifferencetoNextLevel = xpForNextLevel - currentXP;
        totalXpDifference = xpForNextLevel - (baseXP * (currentLevel-1) * (currentLevel-1));

        fillAmount = (float)xpDifferencetoNextLevel / totalXpDifference;
        reverseFillAmout = 1 - fillAmount;

        xpPotential = 5 * (currentLevel-1);
    }
}
