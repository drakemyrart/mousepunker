using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadInformation : MonoBehaviour
{
    public static void LoadAllInformation()
    {
        GameManager.NowLevel = PlayerPrefs.GetInt("PLAYERLEVEL");
        GameManager.PlayerName = PlayerPrefs.GetString("PLAYERNAME");
        GameManager.Unity = PlayerPrefs.GetInt("UNITY");
        GameManager.Understanding = PlayerPrefs.GetInt("UNDERSTANDING");
        GameManager.Care = PlayerPrefs.GetInt("CARE");
        GameManager.Autonomy = PlayerPrefs.GetInt("AUTONOMY");
        GameManager.Control = PlayerPrefs.GetInt("CONTROL");
        GameManager.Right = PlayerPrefs.GetInt("RIGHT");
        GameManager.Stress = PlayerPrefs.GetInt("STRESS");
    }
}
