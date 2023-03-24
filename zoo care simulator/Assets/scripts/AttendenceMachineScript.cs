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
    
    public string TaskCompletionGrade;
    public string AverageHealthGrade;

    [Header("DEBUG VALUES")]
    [SerializeField]
    private float AverageHealthScore;
    [SerializeField]
    private int taskScore;
    [SerializeField]
    string[] GradeList = { "F", "D", "C", "B", "A" };

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
        if (AverageHealthScore < 20)
        {
            AverageHealthGrade = GradeList[0];
        }
        else if (AverageHealthScore >= 20 && AverageHealthScore < 40)
        {
            AverageHealthGrade = GradeList[1];
        }
        else if (AverageHealthScore >= 40 && AverageHealthScore < 60)
        {
            AverageHealthGrade = GradeList[2];
        }
        else if (AverageHealthScore >= 60 && AverageHealthScore < 80)
        {
            AverageHealthGrade = GradeList[3];
        }
        else if (AverageHealthScore >= 80)
        {
            AverageHealthGrade = GradeList[4];
        }
        //DEBUG
        print("average status of all animals: " + AverageHealthGrade);
        print("average task completion of all animals: " + GradeList[taskScore]);

    }
}
