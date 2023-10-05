using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PowerOrg", menuName = "Simulation System/PowerOrg", order = 51)]
public class PowerOrg : ScriptableObject
{    
    [SerializeField]
    private string orgName;

    [SerializeField]
    private string description;

    [SerializeField]
    private int SocioeconomicStatus;

    [SerializeField]
    private int ideology;

    [SerializeField]
    private int Amountvalue;


}
