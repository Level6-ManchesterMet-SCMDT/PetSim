using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public int currentMoney;
    [SerializeField] private GradeMenuScript GMScript;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentMoney);
    }

    public void MoneyIncrease(int reward)
    {
        currentMoney += reward;
    }
}
