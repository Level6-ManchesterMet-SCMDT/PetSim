using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ZooShopManager : MonoBehaviour
{
    [SerializeField] private GameObject Desktop;
    [SerializeField] private GameObject ZooShop;
    [SerializeField] private TMP_InputField MoneyDisplay;
    private int moneyAmount;
    private int testMoney = 100;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Desktop.SetActive(true);
        ZooShop.SetActive(false);
        moneyAmount = testMoney;
        MoneyDisplay.text = moneyAmount.ToString();

    }

    public void Subtract20()
    {
        if (moneyAmount - 20 >= 0)
        {
            moneyAmount -= 20;
            MoneyDisplay.text = moneyAmount.ToString();
        }
        else
        {
            Debug.Log("Insufficient Funds");
        }
    }
    
    public void Subtract50()
    {
        if (moneyAmount - 50 >= 0)
        {
            moneyAmount -= 50;
            MoneyDisplay.text = moneyAmount.ToString();
        }
        else
        {
            Debug.Log("Insufficient Funds");
        }
    }
    
    public void Subtract80()
    {
        if (moneyAmount - 80 >= 0)
        {
            moneyAmount -= 80;
            MoneyDisplay.text = moneyAmount.ToString();
        }
        else
        {
            Debug.Log("Insufficient Funds");
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
