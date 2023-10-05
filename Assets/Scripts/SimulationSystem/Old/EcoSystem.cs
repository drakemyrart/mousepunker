using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New EcoSystem", menuName = "Simulation System/EcoSystem", order = 51)]
public class EcoSystem : ScriptableObject
{
    [SerializeField]
    private string EcoSystemName;

    [SerializeField]
    private string description;

    [SerializeField]
    private int ecoType;

    [SerializeField]
    private int AmountHerbavores;

    [SerializeField]
    private int AmountCarnivore;

    [SerializeField]
    private int AmountBirds;

    [SerializeField]
    private int AmountInsects;

    [SerializeField]
    private int AmountInsectivores;
}
