using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Animator Anim;
    [SerializeField] private GameObject firstPrompt;
    [SerializeField] private KeyCode PressToPlay;
    [SerializeField] private GameObject FirstMenu;
    [SerializeField] private GameObject FirstMenuWarp;
    [SerializeField] private GameObject PlayMenu;
    [SerializeField] private GameObject SettingsMenu;
    [SerializeField] private GameObject StoryMenu;
    private Coroutine warpCoroutine;
    
    // Start is called before the first frame update
    void Start()
    {
        firstPrompt.SetActive(false);
        FirstMenu.SetActive(false);
        PlayMenu.SetActive(false);
        StoryMenu.SetActive(false);
        FirstMenuWarp.SetActive(false);
        SettingsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(PressToPlay))
        {
            Anim.SetTrigger("GameStart");
            firstPrompt.SetActive(false);
        }  
    }
    
    public void AlertObservers(string message)
    {
        if (message.Equals("IntroAnimationEnded"))
        {
            firstPrompt.SetActive(true);
        }
    }

    public void ShowFirstMenu(string message)
    {
        if (message.Equals("TravelAnimationEnded"))
        {
            if (warpCoroutine != null)
                StopCoroutine(warpCoroutine);
            warpCoroutine = StartCoroutine(WarpEffect());
            //FirstMenuWarp.SetActive(true);
            //FirstMenu.SetActive(true);
        }
    }

    IEnumerator WarpEffect()
    {
        FirstMenuWarp.SetActive(true);
        yield return new WaitForSeconds(1.3f);
        FirstMenu.SetActive(true);
        FirstMenuWarp.SetActive(false);
        yield return null; 
    }
    
    public void ShowPlayMenu(string message)
    {
        if (message.Equals("TravelAnimationEnded"))
        {
            PlayMenu.SetActive(true);
        }
    }
    
    public void ShowStoryMenu(string message)
    {
        if (message.Equals("TravelAnimationEnded"))
        {
            StoryMenu.SetActive(true);
        }
    }

    public void ShowSettingsMenu(string message)
    {
        if (message.Equals("TravelAnimationEnded"))
        {
            SettingsMenu.SetActive(true);
        }
    }

    public void PlayButton()
    {
        Anim.SetTrigger("PressPlay");
        StopCoroutine(warpCoroutine);
    }
    
    public void StoryButton()
    {
        Anim.SetTrigger("PressStory");
    }

    public void SettingsButton()
    {
        Anim.SetTrigger("PressSettings");
    }

    public void SettingsReverse()
    {
        Anim.SetTrigger("PressOptionsBack");
    }
}
