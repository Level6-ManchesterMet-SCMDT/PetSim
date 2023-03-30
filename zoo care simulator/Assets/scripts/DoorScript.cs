using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Animator[] DoorAnims;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < DoorAnims.Length; i++)
        {
            if (player.transform.position.x > this.transform.position.x)
            {
                DoorAnims[i].SetTrigger("GreaterThan");
                Debug.Log("Greater z" + i);
            }
            else if (player.transform.position.x < this.transform.position.x)
            {
                DoorAnims[i].SetTrigger("LessThan");
                Debug.Log("Lesser z" + i);
            }
            Debug.Log(player.transform.position.x + ", " + player.transform.position.z);
        }
    }
}
