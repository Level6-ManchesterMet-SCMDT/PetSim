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

    // Update is called once per frame
    void Update()
    {


        if (IsPlaying == true)
        {
            if(playDuration> 0)
            {
                transform.Rotate(0, 30 * Time.deltaTime, 0);
                currentPlayDuration -= 1*Time.deltaTime;
            }
            else
            {
                currentPlayDuration = playDuration;
                IsPlaying= false;
            }
        }
    }
    public override void PlayWithToy()
    {
        if (animalInventory.name == "toy")
        {
            base.PlayWithToy();
            IsPlaying= true;
            
        }
    }
}
