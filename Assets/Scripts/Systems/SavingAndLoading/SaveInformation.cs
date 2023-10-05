using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveInformation 
{
    public static void SaveAllInformation()
    {
        PlayerPrefs.SetInt("PLAYERLEVEL", GameManager.NowLevel);
        PlayerPrefs.SetString("PLAYERNAME", GameManager.PlayerName);
        PlayerPrefs.SetInt("UNITY", GameManager.Unity);
        PlayerPrefs.SetInt("UNDERSTANDING", GameManager.Understanding);
        PlayerPrefs.SetInt("CARE", GameManager.Care);
        PlayerPrefs.SetInt("AUTONOMY", GameManager.Autonomy);
        PlayerPrefs.SetInt("CONTROL", GameManager.Control);
        PlayerPrefs.SetInt("RIGHT", GameManager.Right);
        PlayerPrefs.SetInt("STRESS", GameManager.Stress);
    }
}
