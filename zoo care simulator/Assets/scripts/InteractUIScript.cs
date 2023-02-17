using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractUIScript : MonoBehaviour
{
    [SerializeField] private GameObject animalStats;
    [SerializeField] private GameObject prompt;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            prompt.SetActive(true);
        }
    }
    
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                animalStats.SetActive(true);
                prompt.SetActive(false);
            }
            else if (Input.GetKey(KeyCode.Escape))
            {
                animalStats.SetActive(false);
                prompt.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animalStats.SetActive(false);
            prompt.SetActive(false);
        }
    }
}
