using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Animator Anim;
    [SerializeField] private GameObject firstPrompt;
    [SerializeField] private KeyCode PressToPlay;
    [SerializeField] private GameObject FirstMenu;

    // Start is called before the first frame update
    void Start()
    {
        firstPrompt.SetActive(false);
        FirstMenu.SetActive(false);
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
            FirstMenu.SetActive(true);
        }
    }

    public void PlayButton()
    {
        Anim.SetTrigger("PressPlay");
    }
}
