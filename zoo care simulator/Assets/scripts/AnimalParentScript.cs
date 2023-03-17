using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    [SerializeField]
    [Tooltip("play animation in seconds")]
    protected float playAimationDuration = 5;
    private string healthy = "healthy";

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
        
    }

}
