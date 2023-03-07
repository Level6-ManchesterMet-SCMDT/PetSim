using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject PausePrimary;
    [SerializeField] private GameObject PauseHelp;
    [SerializeField] private GameObject PauseOptions;
    [SerializeField] private FirstPersonController fpsController;
    
    
    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
        PausePrimary.SetActive(false);
        PauseHelp.SetActive(false);
        PauseOptions.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePauseMenu();
        }
    }
    
    private void TogglePauseMenu()
    {
        PauseMenu.SetActive(!PauseMenu.activeInHierarchy);
        PausePrimary.SetActive(PauseMenu.activeInHierarchy);
        PauseHelp.SetActive(false);
        PauseOptions.SetActive(false);
        fpsController.m_MouseLook.SetCursorLock(!PauseMenu.activeInHierarchy);
        fpsController.enabled = !PauseMenu.activeInHierarchy;
    }

    
    public void Restart()
    {
        Debug.Log("Restart Pressed");
    }
    public void Help()
    {
        Debug.Log("Help Pressed");
        PausePrimary.SetActive(false);
        PauseHelp.SetActive(true);
        
    }
    public void Options()
    {
        Debug.Log("Options Pressed");
        PausePrimary.SetActive(false);
        PauseOptions.SetActive(true);
    }
    public void MainMenu()
    {
        Debug.Log("MainMenu Pressed");
    }

    public void Back()
    {
       PauseHelp.SetActive(false);
       PauseOptions.SetActive(false);
       PausePrimary.SetActive(true);
    }
    
}
