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
    public int currentInventroyIndex;
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
    }

    private void RaycastInteract(float reach)
    {
        RaycastHit hitinfo = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out hitinfo,reach)){

            
            interactedItem = hitinfo.collider.gameObject;//grabs the item;

            if(interactedItem.tag=="food"||interactedItem.tag== "medicene"|| interactedItem.tag == "toy")//check if it is an interactble
            {
                //DEBUG
                print("hit pickup");
                Debug.DrawRay(ray.origin, ray.direction * 10, Color.green, 10f);
            }
        }
        


        
    }
}
