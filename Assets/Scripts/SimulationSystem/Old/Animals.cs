using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Animals", menuName = "Simulation System/Animals", order = 51)]
public class Animals : ScriptableObject
{
    [SerializeField]
    private string animalName;

    [SerializeField]
    private string description;

    [SerializeField]
    private int Class;

    [SerializeField]
    private int type;

    [SerializeField]
    private int food;

    [SerializeField]
    private int water;

    [SerializeField]
    private bool partner;

    [SerializeField]
    private bool saftey;
}
