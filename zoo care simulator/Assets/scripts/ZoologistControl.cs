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

    [SerializeField] private GameObject[] Highlights;
    [SerializeField] private Image[] slots;
    [SerializeField] private Sprite[] icons;
    


    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            RaycastInteract(reachRange);
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

        if (Input.GetKeyDown(KeyCode.Alpha1))
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
        else if (Input.GetKeyDown(KeyCode.Alpha2))
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
        else if (Input.GetKeyDown(KeyCode.Alpha3))
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
        else if (Input.GetKeyDown(KeyCode.Alpha4))
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
        else if (Input.GetKeyDown(KeyCode.Alpha5))
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
        else if (Input.GetKeyDown(KeyCode.Alpha6))
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
            slots[currentInventroyIndex].sprite = null;
            slots[currentInventroyIndex].enabled = false;
            
            

        }
    }

    private void RaycastInteract(float reach)
    {
        RaycastHit hitinfo = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out hitinfo,reach)){

            
            interactedItem = hitinfo.collider.gameObject;//grabs the item;
            

            if (interactedItem.tag == "food" || interactedItem.tag == "medicene" || interactedItem.tag == "toy")//check if it is an interactble
            {
                //DEBUG
                print("hit pickup");
                Debug.DrawRay(ray.origin, ray.direction * reachRange, Color.green, 10f);

                for (int i = 0; i < inventorySlots.Length; i++)//finds first free slot in the inventory
                {
                    if(inventorySlots[i] == null)
                    {
                        inventorySlots[i] = interactedItem;//puts it into the slot
                        slots[i].enabled = true;
                        if (interactedItem.CompareTag("food"))
                        {
                            slots[i].sprite = icons[0];
                        }
                        else if(interactedItem.CompareTag("medicene"))
                        {
                            slots[i].sprite = icons[1];
                        }
                        else if (interactedItem.CompareTag("toy"))
                        {
                            slots[i].sprite = icons[2];
                        }
                        else
                        { slots[i].sprite = icons[3];}
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
