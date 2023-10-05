using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New EconomicSystem", menuName = "Simulation System/EconomicSystem", order = 51)]
public class EconomicSystem : ScriptableObject
{
    [SerializeField]
    private string ecoName;

    [SerializeField]
    private string description;

    [SerializeField]
    private int SocioeconomicStatus;

    [SerializeField]
    private int ideology;

    [SerializeField]
    private int Amountvalue;
}
