using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalParentScript : MonoBehaviour
{
    public string animalName;
    public int maxValue;
    public int health = 50;
    public int mood = 50;
    public int hunger=50;
    public float growthRate;
    public float age;
    [SerializeField]
    [Tooltip("aliments for matching with the correct medicene")]
    protected string[] alimentsList ={"flu","rash"};
    public string CurrentAliment;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
}
