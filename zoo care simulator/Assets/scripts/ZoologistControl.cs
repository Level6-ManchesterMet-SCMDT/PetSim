using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoologistControl : MonoBehaviour
{
    [SerializeField]
    private Transform inventroyStorageLocation;
    [SerializeField]
    private Transform dropItemLocation;
    [SerializeField]
    [Tooltip("the inventory slots of the player")]
    private GameObject[] inventorySlots;
    [Tooltip("which slots is the inventory currently selected")]
    public int currentInventroyIndex=0;
    private GameObject interactedItem;
    [SerializeField]
    private float reachRange = 2;

    [SerializeField] private GameObject[] Highlights; //Array of images that show the selected inventory slot
    [SerializeField] private Image[] slots; //Array oof all the available slots in the hotbar
    [SerializeField] private Sprite[] icons; //Array of possible icons that can be placed in the hotbar
    private string[] ItemTags = new []{"Fish", "Fruit","medicene","Ball","Teddy","food","toy",}; //ADD FUTURE ITEMS HERE - IN ORDER OF ICONS ARRAY
    



    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            RaycastInteract(reachRange);
        }
        if (Input.GetMouseButtonDown(1))
        {
            RaycastUseItem(reachRange);
        }
        
        for( int i = 0; i < inventorySlots.Length; i++)//moves all item into storage
        {
            if (inventorySlots[i] != null)//checks if there is anything, else move on
            {
                inventorySlots[i].transform.position = inventroyStorageLocation.transform.position;
            }
        }
        /*if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            currentInventroyIndex++;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            currentInventroyIndex--;
        }*/

        if (Input.GetKeyDown(KeyCode.Alpha1))//Highlights the first bubble. ensures the other bubbles are not highlighted
        {
            currentInventroyIndex = 0;
            for (int i = 0; i < Highlights.Length; i++)
            {
                if (i == currentInventroyIndex)
                {
                    Highlights[i].SetActive(true);
                }
                else
                {
                    Highlights[i].SetActive(false);
                }
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))//Highlights the second bubble. ensures the other bubbles are not highlighted
        {
            currentInventroyIndex = 1;
            
            for (int i = 0; i < Highlights.Length; i++)
            {
                if (i == currentInventroyIndex)
                {
                    Highlights[i].SetActive(true);
                }
                else
                {
                    Highlights[i].SetActive(false);
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))//Highlights the third bubble. ensures the other bubbles are not highlighted
        {
            currentInventroyIndex = 2;
            for (int i = 0; i < Highlights.Length; i++)
            {
                if (i == currentInventroyIndex)
                {
                    Highlights[i].SetActive(true);
                }
                else
                {
                    Highlights[i].SetActive(false);
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4)) //Highlights the fourth bubble. ensures the other bubbles are not highlighted
        {
            currentInventroyIndex = 3;
            for (int i = 0; i < Highlights.Length; i++)
            {
                if (i == currentInventroyIndex)
                {
                    Highlights[i].SetActive(true);
                }
                else
                {
                    Highlights[i].SetActive(false);
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5)) //Highlights the fifth bubble. ensures the other bubbles are not highlighted
        {
            currentInventroyIndex = 4;
            for (int i = 0; i < Highlights.Length; i++)
            {
                if (i == currentInventroyIndex)
                {
                    Highlights[i].SetActive(true);
                }
                else
                {
                    Highlights[i].SetActive(false);
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))//Highlights the sixth bubble. ensures the other bubbles are not highlighted
        {
            currentInventroyIndex = 5;
            for (int i = 0; i < Highlights.Length; i++)
            {
                if (i == currentInventroyIndex)
                {
                    Highlights[i].SetActive(true);
                }
                else
                {
                    Highlights[i].SetActive(false);
                }
            }
        }
        
        if (currentInventroyIndex < 0 ) {
            currentInventroyIndex = 0;
        }
        if(currentInventroyIndex >= inventorySlots.Length)
        {
            currentInventroyIndex = inventorySlots.Length - 1;
        }

        //drop selected item
        if (Input.GetKeyDown("q") && inventorySlots[currentInventroyIndex] != null)
        {
            inventorySlots[currentInventroyIndex].transform.position = dropItemLocation.position;
            inventorySlots[currentInventroyIndex].GetComponent<Rigidbody>().velocity = Vector3.zero;
            inventorySlots[currentInventroyIndex]=null;
            slots[currentInventroyIndex].sprite = null; //removes the sprite from the inventory slot/bubble
            slots[currentInventroyIndex].enabled = false; //deactivates the image component storing the item
            
            

        }
    }

    private void RaycastInteract(float reach)
    {
        RaycastHit hitinfo = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hitinfo, reach)) {


            interactedItem = hitinfo.collider.gameObject;//grabs the item;

            for (int t = 0; t < ItemTags.Length; t++) //Checks the iteractedItem tag against the array of tags
            {
                if (interactedItem.CompareTag(ItemTags[t])) //check if it is an interactble
                {
                    //DEBUG
                    print("hit pickup");
                    Debug.DrawRay(ray.origin, ray.direction * reachRange, Color.green, 10f);

                    for (int i = 0; i < inventorySlots.Length; i++) //finds first free slot in the inventory
                    {
                        if (inventorySlots[i] == null)
                        {
                            inventorySlots[i] = interactedItem; //puts it into the slot
                            slots[i].enabled = true;
                            slots[i].sprite = icons[t]; //set the sprite to the corresponding icon
                            break;
                        }
                    }
                }

                else
                {
                    Debug.DrawRay(ray.origin, ray.direction * reachRange, Color.red, 10f);
                }

            }



        
        }
    }
    private void RaycastUseItem(float reach)//for checking if item is used on animal
    {
        RaycastHit hitinfo = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hitinfo, reach))
        {
            interactedItem = hitinfo.collider.gameObject;//grabs the item;
             if (interactedItem.tag == "animal")//check if the player is interacting with an animal
            {
                //DEBUG
                Debug.DrawRay(ray.origin, ray.direction * reachRange, Color.yellow, 10f);

                //gets the animal parant script
                AnimalParentScript Animal=interactedItem.GetComponent<AnimalParentScript>();

                //puts selected item into animal's inventory, and removes it from player's if it is not empty

                var item = inventorySlots[currentInventroyIndex];
                if (item != null && Animal.animalInventory==null)//check if player hand is not empty and if animal inventory is empty
                {
                    //moves the player's item into animal's inventory
                     
                    Animal.animalInventory = inventorySlots[currentInventroyIndex];
                    inventorySlots[currentInventroyIndex]= null;
                }
            }
            else
            {
                //DEBUG
                Debug.DrawRay(ray.origin, ray.direction * reachRange, Color.red, 10f);
            }
        }
    }
}
