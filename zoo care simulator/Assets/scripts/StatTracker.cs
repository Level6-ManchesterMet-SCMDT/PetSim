using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class StatTracker : MonoBehaviour
{
    [Header("Setup")]
    //[SerializeField] private ScrollRect scroller;
    [SerializeField] private Scrollbar scrollbar;
    private float timer = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        scrollbar.value = 1f;
        StartCoroutine(ScrollLoop(scrollbar, timer));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ScrollLoop(Scrollbar vertScroll, float duration)
    {
        while (vertScroll.value>0)
        {
            yield return new WaitForSeconds(0.1f);
            vertScroll.value -= 0.01f;
            if (vertScroll.value <= 0.005)
            {
                vertScroll.value = 3f;
            }
        }
    }

    /*public void ScrollReset()
    {
        if (scroller.GetComponentInChildren<Scrollbar>().value < 0.01)
        {
            scroller.GetComponentInChildren<Scrollbar>().value = 1;
        }
    }*/
}
