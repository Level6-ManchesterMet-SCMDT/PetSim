using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
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
        if (player.transform.position.x > this.transform.position.x || player.transform.position.z > this.transform.position.z)
        {
            Debug.Log("Open Outward");
        }
        else
        {
            Debug.Log("Open Inward");
        }
    }
}
