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
    protected bool IsPlaying=false;

    public void Feed(int foodvalue=10)//increases hunger bar from feeding
    {
        hunger += foodvalue;
    }
    public void GiveMedicine(string medicine)//input what the medicene cures and it increases health
    {
        if (medicine == CurrentAliment)
        {
            CurrentAliment = "healthy";
            health += 10;
        }
        else
        {
            health -= 10;
        }
    }
    public void IncreaseHappiness(int modifier=10)//increases happiness placeholder
    {
        mood += modifier;
    }
    virtual public void PlayWithToy() //Remember to do a overide in the derived classes
    {
        IncreaseHappiness();
    }

}
