using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Building", menuName = "Simulation System/Buildings", order = 51)]
public class Buildings : ScriptableObject
{
    [SerializeField]
    private string buildingName;

    [SerializeField]
    private string description;

    [SerializeField]
    private int buildingType;

    [SerializeField]
    private int food;

    [SerializeField]
    private int water;

    [SerializeField]
    private int saftey;

    [SerializeField]
    private int noice;

    [SerializeField]
    private int ideology;

    [SerializeField]
    private int Richness;
}
