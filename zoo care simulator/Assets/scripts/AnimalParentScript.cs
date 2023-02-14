using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalParentScript : MonoBehaviour
{
    public string animalName;
    public int maxValue=100;
    public int health = 50;
    public int mood = 50;
    public int hunger=50;
    public float growthRate;
    public float age;
    [SerializeField]
    [Tooltip("aliments for matching with the correct medicene")]
    protected string[] alimentsList ={"flu","rash"};
    public string CurrentAliment="healthy";
    [Tooltip("for what the animal recives from the player")]
    public GameObject animalInventory;

    [SerializeField]
    protected bool IsPlayingToy=false;

    public void Feed(int foodvalue=10)//increases hunger bar from feeding
    {
        hunger += foodvalue;
        Destroy(animalInventory);
    }
    public void EatMedicine(int modifier=10)//input what the medicene cures and it increases health
    {
        health += modifier;
        Destroy(animalInventory);
    }
    public void IncreaseHappiness(int modifier=10)//increases happiness placeholder
    {    
        if (IsPlayingToy==false) 
        { 
            mood += modifier; 
        }
        IsPlayingToy = true;
    }
    protected virtual void PlayingWithToy()
    {
        IncreaseHappiness();
        IsPlayingToy = false;
    }
    virtual public void Update()
    {
        //check animal inventory
        if (animalInventory.tag == "toy")
        {
            PlayingWithToy();
        }
        else if (animalInventory.tag == "medicene")
        {
            
            EatMedicine();
        }
        else if (animalInventory.tag == "food")
        {
            Feed();
        }
    }

}
