using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class basicTasks : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> animalList;//list of animals to check
    [SerializeField]
    private List<GameObject> sickAnimals;//list of sick animals
    public bool allCured = false;
    public bool allFed = false;
    public bool allPlayed = false;
    public bool isClean = false;
    public bool cleanEnclosure = false;

    // Update is called once per frame
    void Update()
    {
        checkBasicNeeds();
        assignSickAnimals();
    }
    private void Start()
    {

    }
    void checkBasicNeeds()
    {
        bool fed = true;
        bool played = true;
        bool cured = true;
        bool clean = true;
        bool enclosureclean = true;

        foreach (var animal in animalList)//checks each animal for basic needs
        {
            var animalscript = animal.GetComponent<AnimalParentScript>();

            if (animalscript.Fed == false)//if at least one is not fed then it returns false
            {
                fed = false;
            }
            if (animalscript.Played == false)//if at least one is not played with it returns false
            {
                played = false;
            }
        }
        foreach (var animal in sickAnimals)//checks sick animals
        {
            var animalscript = animal.GetComponent<AnimalParentScript>();
            if (animalscript.Cured == false)
            {
                cured = false;
            }
        }
        allFed = fed;
        allPlayed = played;
        allCured = cured;
    }
    void assignSickAnimals()//finds all sick animals, then puts them into a list
    {
        sickAnimals.Clear();
        foreach (var animal in animalList)
        {
            var animalscript = animal.GetComponent<AnimalParentScript>();
            if (animalscript.CurrentAliment != "healthy")
            {
                sickAnimals.Add(animal);
            }
        }
    }
    public void dayReset()//refereshs the tasks and resets the animals stats
    {
        assignSickAnimals();//reassigns a new list of sick animals

        foreach (var animal in animalList)//resets each animal
        {
            var animalscript = animal.GetComponent<AnimalParentScript>();
            animalscript.resetneeds();
        }
    }
}
