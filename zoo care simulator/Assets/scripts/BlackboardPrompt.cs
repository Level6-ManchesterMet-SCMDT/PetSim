using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    
    [Header("Animal Details")]
    [SerializeField]private string[] tasks;
    public enum Species { Penguin, Panda, Meerkat, Coati, Sloth };
    public Species _species;
    
    private bool inTrigger = false;
    private int nextTask = 1;
    private int completed = 0;
    
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
