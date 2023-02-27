using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoologistControl : MonoBehaviour
{
    [SerializeField]
    private Transform inventroyStorageLocation;
    [SerializeField]
    [Tooltip("the inventory slots of the player")]
    private GameObject[] inventorySlots;
    [Tooltip("which slots is the inveontory currently slected")]
    public int currentInventroyIndex=0;
    private GameObject interactedItem;
    [SerializeField]
    private float reachRange = 2;


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
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            currentInventroyIndex++;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            currentInventroyIndex--;
        }
        if (currentInventroyIndex < 0 ) {
            currentInventroyIndex = 0;
        }
        if(currentInventroyIndex >= inventorySlots.Length)
        {
            currentInventroyIndex = inventorySlots.Length - 1;
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
