using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimalParentScript : MonoBehaviour
{
    [Tooltip("Displays in the notepad as the name")]public string animalName;
    [SerializeField]
    protected int maxValue=100;
    public float health = 50;
    public float mood = 50;
    public float hunger=50;
    public float growthRate;
    public float age;
    public bool isDead = false;
    [SerializeField]
    [Tooltip("aliments for matching with the correct medicene")]
    protected string[] alimentsList ={"flu","rash"};
    public string CurrentAliment="healthy";
    [Tooltip("for what the animal recives from the player")]
    public GameObject animalInventory;

    [SerializeField]
    protected bool IsPlayingToy=false;
    [SerializeField]
    [Tooltip("play animation in seconds")]
    protected float playAimationDuration = 5;
    private string healthy = "healthy";
    
    [SerializeField]
    [Tooltip("lower bound for the stats when generation")]
    private int lowerBoundModifier=50;
    [SerializeField]
    [Tooltip("how much time passes before hunger decreases by 1 in seconds")]
    private int hungerDecayRate = 1;
    [SerializeField]
    [Tooltip("how much time passes before mood decreases by 1 in seconds")]
    private int moodDecayRate = 1;
    [SerializeField]
    [Tooltip("how much time passes before health decreases by 1 in seconds if afflicted or low mood/hunger")]
    private int healthDecayRate = 1;
    [SerializeField]
    [Tooltip("how much time passes before health increases by 1 in seconds passively when hunger and mood is high")]
    private int healthRestoreRate = 1;
    [SerializeField]
    [Tooltip("maximun chance out of 100% to become afflicted at 0 hunger and 0 happiness")]
    private float maxChanceToGetAfflicted = 70;
    [SerializeField]
    [Tooltip("DEBUGGING")]
    private float currentHappinessAfflictedChance;
    [SerializeField]
    [Tooltip("DEBUGGING")]
    private float currenthungerAfflictedChance;
    public void Feed(int foodvalue=10)//increases hunger bar from feeding
    {
        hunger += foodvalue;
        Destroy(animalInventory);
    }
    public void EatMedicine(int modifier=10)//input what the medicene cures and it increases health
    {
        var mediciene=animalInventory.GetComponent<mediceneScript>();

        if (CurrentAliment != healthy)//medicene does nothing if the animal is healthy
        {
            if (mediciene.GetAliment() == CurrentAliment)//If correct medicene used cures the aliment and icreases health
            {
                health += modifier;
                CurrentAliment = healthy;
            }
            else//if wrong medicene used it reduces health and aliment stays
            {
                health -= modifier;
            }
        }
        Destroy(animalInventory);//eats the medicene for all cases
    }

     protected IEnumerator playingWithToy(float duration)//triggers once when animal recives toy
    {
        //stops duplication
        if (IsPlayingToy==true)
        {
            yield break;
        }
        IsPlayingToy = true;
        //improves mood
        print("add "+mood+" mood");
        mood += 10;
        yield return new WaitForSeconds(duration);
        IsPlayingToy= false;
        animalInventory = null;
    }
    virtual protected void PlayToyAnimation()//for the animal's play animation
    {
        if(IsPlayingToy== true)
        {
            //placeholder animation
            transform.Rotate(0, 50 * Time.deltaTime, 0);
        }
    }
    virtual public void Update()//make sure to call override on all child methods and that it has a base.Update()
    {

        //check animal inventory
        if (animalInventory != null)
        {
            if (animalInventory.tag == "toy")
            {
                StartCoroutine(playingWithToy(playAimationDuration));
                PlayToyAnimation();
                
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
        AdvanceTimeStatus();
    }
    /// <summary>
    /// for generating random stats upon spawning the animal into the game, put it in start method
    /// </summary>
    protected void generateRandomInitalStats()
    {
        health=Random.Range(lowerBoundModifier, 100);
        mood = Random.Range(lowerBoundModifier, 100);
        //hunger = Random.Range(lowerBoundModifier, 100);
        hunger = maxValue;
    }
    protected void DecayHunger()
    {
        if (hunger >= 0)
        {
            hunger = hunger - Time.deltaTime / hungerDecayRate;
        }
        
    }
    protected void decayHappiness()
    {
        if (mood >= 0)
        {
            mood = mood - Time.deltaTime / moodDecayRate;
        }
    }
    protected void decayHealth()
    {
        if (health >= 0)
        {
            health = Time.deltaTime / healthDecayRate;
        }
    }
    protected void BecomeAfflicted()
    {
        if (CurrentAliment == "healthy")
        {
            int length = alimentsList.Length;
            int index=Random.Range(0, length);
            CurrentAliment= alimentsList[index];
        }
    }
    
    virtual protected void AdvanceTimeStatus()//logic for the base stats
    {
        //hunger and happiness goes down all the time
        DecayHunger();
        decayHappiness();


        //the lower the hunger and happiness, the higher the risk of catching an infection, based on maxChanceToGetIll%/2 x hunger + maxChanceToGetIll%/2 x happiness

        //liner decay to 0
        //currentHappinessAfflictedChance = maxChanceToGetAfflicted / 2-((maxChanceToGetAfflicted / 100) / 2) * mood;      
        //currenthungerAfflictedChance = maxChanceToGetAfflicted / 2-((maxChanceToGetAfflicted / 100) / 2) * hunger;

        //exponential decay to 0
        //                                                            steepness     
        currentHappinessAfflictedChance =  ((maxChanceToGetAfflicted / 2 / 100) ) * (   2    /mood)  *100;
        currenthungerAfflictedChance =  ((maxChanceToGetAfflicted / 2 / 100) ) *    (   2    /hunger)  *100;
        //locks the values within lower bounds
        if (currentHappinessAfflictedChance <= 0)
        {
            currentHappinessAfflictedChance = 0;
        }
        if(currenthungerAfflictedChance <= 0)
        {
            currenthungerAfflictedChance = 0;
        }
        int currentAfflictedChance = (int)(currenthungerAfflictedChance + currentHappinessAfflictedChance);
        //locks value within upper bounds
        if (currentAfflictedChance > 100) {
            currentAfflictedChance = 100;
        }
        //print(currentIllChance);
        int randomNumber=Random.Range(0, maxValue);
        //will animal get afflicted
        //requires fizing later
        if (randomNumber <= currentAfflictedChance)
        {
            BecomeAfflicted();
        }
        //decay health if ill
        if (CurrentAliment != healthy)
        {
            decayHealth();
        }
    }
}
