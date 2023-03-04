using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class HandbookController : MonoBehaviour
{
    [SerializeField] private GameObject handbookCanvas;
    [SerializeField] private FirstPersonController fpsScript;

    [SerializeField] private AudioSource bFlip, bOpen, bClose;
    // Start is called before the first frame update
    void Start()
    {
        handbookCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        OpenHandbook();
    }

    private void OpenHandbook()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            handbookCanvas.SetActive(!handbookCanvas.activeInHierarchy);
            fpsScript.m_MouseLook.SetCursorLock(!handbookCanvas.activeInHierarchy);
            GetComponent<FirstPersonController>().enabled = !handbookCanvas.activeInHierarchy;
            

        }
    }
}
