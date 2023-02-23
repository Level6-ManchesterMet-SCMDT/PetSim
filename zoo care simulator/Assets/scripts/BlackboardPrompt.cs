using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackboardPrompt : MonoBehaviour
{
    [SerializeField] private GameObject prompt;
    [SerializeField] private Text taskText;
    [SerializeField] private Toggle taskCompletion;

    private string[] tasks= new string[] { "Feed the Penguins", "Clean Penguin Enclosure", "Treat Unwell Penguins", "Set Penguin Thermostat", "Clock Out"};
    private bool inTrigger = false;
    private int nextTask = 1;
    private int completed = 0;

    private void Start()
    {
        taskText.text = tasks[0];
        Debug.Log(completed + "/" + tasks.Length + " tasks completed");
    }

    private void Update()
    {
        TaskSystemTest();
    }

    private void TaskSystemTest()
    {
        if (Input.GetKeyDown(KeyCode.L) && taskCompletion.isOn == false)
        {
            taskCompletion.isOn = !taskCompletion.isOn;
            completed++;
            DailyQuota();
        }
        
        if (inTrigger && Input.GetKeyDown(KeyCode.E))
        {
            if (nextTask < tasks.Length && taskCompletion.isOn == true)
            {
                taskText.text = tasks[nextTask];
                nextTask++;
                taskCompletion.isOn = false;
            }
        }
    }

    private void DailyQuota()
    {
        Debug.Log(completed + "/" + tasks.Length + " tasks completed");
        if (completed == tasks.Length)
        {
            Debug.Log("Congratulations on completing the quota");
        }
    }
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            prompt.SetActive(true);
            inTrigger = true;
        }
    }
    


    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            prompt.SetActive(false);
            inTrigger = false;
        }
    }
}
