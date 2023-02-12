using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//inherits from parent class
public class PandaScript : AnimalParentScript
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void PlayWithToy()
    {
        if (animalInventory.name == "toy")
        {
            base.PlayWithToy();
            transform.Rotate(0, 30 * Time.deltaTime,0);
        }
    }
}
