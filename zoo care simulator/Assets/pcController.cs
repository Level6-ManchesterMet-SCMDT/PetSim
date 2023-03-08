using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class pcController : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject pcCam;
    [SerializeField] private GameObject prompt;
    
    // Start is called before the first frame update
    void Start()
    {
        prompt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        prompt.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        prompt.SetActive(false);
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                player.GetComponent<FirstPersonController>().m_MouseLook.SetCursorLock(false);
                player.GetComponent<FirstPersonController>().enabled = false;
                player.GetComponent<ZoologistControl>().enabled = false;
                player.GetComponentInChildren<Camera>().enabled = false;
                pcCam.GetComponent<Camera>().enabled = true;
                prompt.SetActive(false);
            }
            else if (Input.GetKey(KeyCode.R))
            {
                player.GetComponent<FirstPersonController>().enabled = true;
                player.GetComponent<FirstPersonController>().m_MouseLook.SetCursorLock(true);
                player.GetComponent<ZoologistControl>().enabled = true;
                player.GetComponentInChildren<Camera>().enabled = true;
                pcCam.GetComponent<Camera>().enabled = false;
                prompt.SetActive(true);
            }

        }
        
    }
    
    
}
