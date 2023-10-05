using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New LandAlotment", menuName = "Simulation System/LandAlotment", order = 51)]
public class LandAlotment : ScriptableObject
{
    [SerializeField]
    private string LandName;

    [SerializeField]
    private string description;

    [SerializeField]
    private int ecoType;

    [SerializeField]
    private int food;

    [SerializeField]
    private int water;

    [SerializeField]
    private int noice;

    [SerializeField]
    private int landType;

    [SerializeField]
    private int buildingCount;

    [SerializeField]
    private List<Buildings> buildinglist;
}
