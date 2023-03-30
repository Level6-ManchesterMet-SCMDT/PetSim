using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttendenceMachineScript : MonoBehaviour
{
    //script to caculate the grades of how many tasks are completed, the average health of animals,
    //and the clock out which would reset the tasks for the day
    [SerializeField]
    [Tooltip("put the chalkboards that are assigned to each enclosure here")]
    private GameObject[] TaskBoards;
    [SerializeField]
    public Transform NewDayPos;
    [SerializeField] private GameObject GradeMenu;
    public string TaskCompletionGrade;
    public string AverageHealthGrade;

    [Header("DEBUG VALUES")]
    [SerializeField]
    public float AverageHealthScore;
    [SerializeField]
    private int taskScore;
    [SerializeField]
    string[] GradeList = { "F", "E", "D", "C", "B", "A", "S"};
    [SerializeField] private GameObject[] Disable;

    private void Start()
    {
        GradeMenu.SetActive(false);
    }

    void Update()
    {
        
    }
    public void caculateGradeAndClockOut()
    {
        float totalHealthScore = 0;
        float totalTaskScore = 0;
        int activeEnclosures = 0;

        foreach (var TaskBoard in TaskBoards)//get basicTask script in each task board
        {
            var taskManager = TaskBoard.GetComponent<basicTasks>();
            //checks if the enclosure is active/purchased, otherwise it is skipped int the final score tally
            if (taskManager.EnclosureActive == true)
            {
                activeEnclosures++;
                //gets the total health score
                totalHealthScore += taskManager.averageAnimalState;

                //gets the total task score
                totalTaskScore += taskManager.tasksCompleted;
            }
            //resets the taskboards for the day
            taskManager.dayReset();
        }
        //gets the overall average
        AverageHealthScore = totalHealthScore / activeEnclosures;
        taskScore = (int)Mathf.Round(totalTaskScore / activeEnclosures);
        //gets the grade values
        TaskCompletionGrade = GradeList[taskScore];
        if (AverageHealthScore < 14)
        {
            AverageHealthGrade = GradeList[0];
        }
        else if (AverageHealthScore >= 14 && AverageHealthScore < 28)
        {
            AverageHealthGrade = GradeList[1];
        }
        else if (AverageHealthScore >= 28 && AverageHealthScore < 42)
        {
            AverageHealthGrade = GradeList[2];
        }
        else if (AverageHealthScore >= 42 && AverageHealthScore < 56)
        {
            AverageHealthGrade = GradeList[3];
        }
        else if (AverageHealthScore >= 56 && AverageHealthScore < 70)
        {
            AverageHealthGrade = GradeList[4];
        }
        else if (AverageHealthScore >= 70 && AverageHealthScore < 84)
        {
            AverageHealthGrade = GradeList[5];
        }
        else if (AverageHealthScore >= 84)
        {
            AverageHealthGrade = GradeList[6];
        }
        //DEBUG
        print("average status of all animals: " + AverageHealthGrade);
        print("average task completion of all animals: " + GradeList[taskScore]);
        float debugScore = AverageHealthScore;
        Debug.Log(debugScore);
        for (int i = 0; i < Disable.Length; i++)
        {
            Disable[i].SetActive(false);
        }
        GradeMenu.SetActive(true);
    }
}
