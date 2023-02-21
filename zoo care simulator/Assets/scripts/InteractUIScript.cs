using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InteractUIScript : MonoBehaviour
{
    [SerializeField] private GameObject animalStats;
    [SerializeField] private GameObject prompt;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Slider hungerSlider;
    [SerializeField] private Slider happinessSilder;
    [SerializeField] private Text alimentDisplay;
    [SerializeField] private Text AnimalName;

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
    public void setHealth(int health)
    {
        healthSlider.value = health;
    }
    public void setHunger(int hunger)
    {
        hungerSlider.value = hunger;
    }
    public void setHappiness(int happiness)
    {
        happinessSilder.value = happiness;
    }
    public void setAliment(string aliment)
    {
        alimentDisplay.text= aliment;
    }
    public void setName(string name)
    {
        AnimalName.text= name;
    }
}
