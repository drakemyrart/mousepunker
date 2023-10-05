using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EcoSystemType : ScriptableObject
{
    [CreateAssetMenu(fileName = "New EcoType", menuName = "Simulation System/EcoType", order = 51)]
    public class EcoSystem : ScriptableObject
    {
        [SerializeField]
        private string EcoSystemTypeName;

        [SerializeField]
        private string description;

        [SerializeField]
        private int ecoType;

        [SerializeField]
        private int Herbavores;

        [SerializeField]
        private int Carnivore;

        [SerializeField]
        private int Birds;

        [SerializeField]
        private int Insects;

        [SerializeField]
        private int Insectivores;

        [SerializeField]
        private int food;

        [SerializeField]
        private int water;

        [SerializeField]
        private int safety;

        [SerializeField]
        private int pollusion;
    }
}
