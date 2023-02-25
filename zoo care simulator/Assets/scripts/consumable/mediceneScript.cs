using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mediceneScript : MonoBehaviour
{
    [SerializeField]
    private string mediceneName;
    [SerializeField]
    [Tooltip("what aliments can it cure, case sensitive to the aliment list")]
    private string CureAliment;

    [Tooltip("can be negative as a tradeoff")]
    public int HealthAdded=0;
    [Tooltip("can be negative as a tradeoff")]
    public int HungerAdded = 0;
    [Tooltip("can be negative as a tradeoff")]
    public int HappinessAdded = 0;

    public string GetName()
    {
        return mediceneName;
    }
    public string GetAliment() {
        return CureAliment;
    }
}
