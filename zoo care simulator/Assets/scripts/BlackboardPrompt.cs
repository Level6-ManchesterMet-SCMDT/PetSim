using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Toggle = UnityEngine.UI.Toggle;

public class BlackboardPrompt : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] private GameObject prompt;
    [SerializeField] private GameObject taskPrefab;
    [SerializeField] private Text taskText;
    [SerializeField] private Toggle taskCompletion;
    [SerializeField] private TMP_Text BlackboardTitle;
    
    
    public enum Species { Penguin, Panda, Meerkat, Coati, Sloth };
    //public enum TaskOutput : int { HungerBoost =1, HappinessBoost =2, HealthBoost =3, Cleaned =4 }
    [Header("Animal Details")]
    [SerializeField] private Species _species;
    [SerializeField]private string[] tasks;
    [Tooltip("HungerBoost =1, HappinessBoost =2, HealthBoost =3, Cleaned =4. In order of task list")]
    [Range(1,4)]
    [SerializeField] private int[] taskValue;
    private bool inTrigger = false;
    private int nextTask = 1;
    private int completed = 0;
    private int input = 3;
    
    
    
    
    private void Start()
    {
        BlackboardTitle.fontSize = 60;
        BlackboardTitle.text = _species + " Tasks";
        for (int i = 0; i < tasks.Length; i++)
        {
            if (i<1)
            {taskText.text = tasks[i];}
            else
            {
                Toggle ToggleClone = Instantiate(taskCompletion, new Vector3(taskCompletion.transform.position.x,taskCompletion.transform.position.y,
                    taskCompletion.transform.position.z), taskCompletion.transform.rotation);
                ToggleClone.transform.parent = taskCompletion.transform.parent;
                ToggleClone.transform.localScale = taskCompletion.transform.localScale;
                ToggleClone.GetComponentInChildren<Text>().text = tasks[i];
            }
        }
        Debug.Log(completed + "/" + tasks.Length + " tasks completed");
        for (int i = 0; i < tasks.Length; i++)
        {
            if (taskValue[i] == 1)
            {
                Debug.Log("Task " + (i+1) + " - " + tasks[i] +" Requires a input of HungerBoost(1) to be completed");
            }
            else if (taskValue[i] == 2)
            {
                Debug.Log("Task " + (i+1) + " - " + tasks[i] +" Requires a input of HappinessBoost(2) to be completed");
            }
            else if (taskValue[i] == 3)
            {
                Debug.Log("Task " + (i+1) + " - " + tasks[i] +" Requires a input of HealthBoost(3) to be completed");
            }
            else if (taskValue[i] == 4)
            {
                Debug.Log("Task " + (i+1) + " - " + tasks[i] +" Requires a input of IsClean(4) to be completed");
            }
            else
            {
                Debug.Log("Error - Missing value");
            }
        }
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
