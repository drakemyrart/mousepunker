using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Individual", menuName = "Simulation System/Individuals", order = 51)]
public class Individuals : ScriptableObject
{
    [SerializeField]
    private string personName;

    [SerializeField]
    private string description;

    [SerializeField]
    private int SocioeconomicClass;

    [SerializeField]
    private int ideology;

    [SerializeField]
    private int economy;


}
