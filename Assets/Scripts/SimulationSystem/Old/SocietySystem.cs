using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SocietySystem", menuName = "Simulation System/SocietySystem", order = 51)]
public class SocietySystem : ScriptableObject
{
    [SerializeField]
    private string SocietyName;

    [SerializeField]
    private string description;

    [SerializeField]
    private int SocioeconomicStatus;

    [SerializeField]
    private int ideology;

    [SerializeField]
    private int Amountvalue;
}
