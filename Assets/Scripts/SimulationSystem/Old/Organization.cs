using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Organization", menuName = "Simulation System/Organization", order = 51)]
public class Organization : ScriptableObject
{
    [SerializeField]
    private string orgName;

    [SerializeField]
    private string description;

    [SerializeField]
    private int orgType;

    [SerializeField]
    private int ideology;

    [SerializeField]
    private int Amountvalue;
}
