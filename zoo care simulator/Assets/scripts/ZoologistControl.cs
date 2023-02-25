using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoologistControl : MonoBehaviour
{
    [SerializeField]
    private GameObject inventroyStorageLocation;
    [SerializeField]
    [Tooltip("the inventory slots of the player")]
    private GameObject[] inventorySlots;
    [Tooltip("which slots is the inveontory currently slected")]
    public int currentInventroyIndex;
    private RaycastHit hitData;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
    }
    private void OnMouseDown()
    {
        // Creates a Ray from the center of the viewport
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
    }
}
