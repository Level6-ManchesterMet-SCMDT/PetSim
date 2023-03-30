using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GradeMenuScript : MonoBehaviour
{
    [SerializeField] private Image GradeValue;
    [SerializeField] private TMP_Text GradeComment;
    [SerializeField] private TMP_Text TimeTaken;
    [SerializeField] private TMP_Text TasksCompleted;
    [SerializeField] private TMP_Text AvgHealth;
    [SerializeField] private Sprite[] PossibleGrades;
    [SerializeField] private AttendenceMachineScript AMScript;
    [SerializeField] private ZoologistControl Player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //string HealthGrade = AMScript.AverageHealthGrade;
        if (AMScript.AverageHealthGrade == "S")
        {
            GradeValue.sprite = PossibleGrades[0];
        }
        else if (AMScript.AverageHealthGrade == "A")
        {
            GradeValue.sprite = PossibleGrades[1];
        }
        else if (AMScript.AverageHealthGrade == "B")
        {
            GradeValue.sprite = PossibleGrades[2];
        }
        else if (AMScript.AverageHealthGrade == "C")
        {
            GradeValue.sprite = PossibleGrades[3];
        }
        else if (AMScript.AverageHealthGrade == "D")
        {
            GradeValue.sprite = PossibleGrades[4];
        }
        else if (AMScript.AverageHealthGrade == "E")
        {
            GradeValue.sprite = PossibleGrades[5];
        }
        else if (AMScript.AverageHealthGrade == "F")
        {
            GradeValue.sprite = PossibleGrades[6];
        }

        float timer = Player.timeStart;
        string minutes = Mathf.Floor(timer / 60).ToString("00");
        string seconds = (timer % 60).ToString("00");
        if (minutes == "00")
        {
            TimeTaken.text = $"{seconds}s";
        }
        else
        {
            TimeTaken.text = $"{minutes}m, {seconds}s";
        }

        AvgHealth.text = AMScript.AverageHealthScore.ToString("f1") + "%";

    }
}
