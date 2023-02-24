using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mediceneScript : MonoBehaviour
{
    [SerializeField]
    private string mediceneName;
    [SerializeField]
    private string CureAliment;

    public string GetName()
    {
        return mediceneName;
    }
    public string GetAliment() {
        return CureAliment;
    }
}
