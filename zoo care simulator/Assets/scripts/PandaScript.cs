using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//inherits from parent class
public class PandaScript : AnimalParentScript
{
    [SerializeField]
    [Tooltip("play animation in seconds")]
    private float playDuration = 5;
    private float currentPlayDuration;
    // Start is called before the first frame update
    void Start()
    {
        currentPlayDuration = playDuration;
    }



}
