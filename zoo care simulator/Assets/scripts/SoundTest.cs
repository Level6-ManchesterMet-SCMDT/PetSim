using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTest : MonoBehaviour
{
    [SerializeField]
    private AudioSource testedSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider player)
    {
        if(player.tag == "Player")
        {
            UnityEngine.Debug.Log("colliding");
        }
        if(Input.GetKeyDown(KeyCode.F) && player.tag == "Player" )
        {
            testedSound.Play();
        }
    }
}
