using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    //Player character information
    public static string PlayerName { get; set; }

    public static int Unity { get; set; }

    public static int Understanding { get; set; }

    public static int Care { get; set; }

    public static int Autonomy { get; set; }

    public static int Control { get; set; }

    public static int Right { get; set; }

    public static int Stress { get; set; }

    public static int NowLevel { get; set; }

}
