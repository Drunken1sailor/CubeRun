using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Profit : SpawnPlayer
{
    [SerializeField] private Text _profit;
    [SerializeField] private Text _totalMoneyTxt;
    [SerializeField] private GameObject[] _productInShop;
    public static int ProfitCounter;
    public static int TotalMoney;
    public static Profit InstanceProfit;

    private void Awake()
    {
        InstanceProfit = this;
        if (!PlayerPrefs.HasKey("SaveMoney"))
        {
            PlayerPrefs.SetInt("SaveMoney",0);
        }
        TotalMoney = PlayerPrefs.GetInt("SaveMoney");
    }

    private void Update()
    {
        _profit.text = "profit: " + ProfitCounter;
        _totalMoneyTxt.text = "$ " + TotalMoney;
    }
    public void AddProfit()
    {
        ProfitCounter += 5;
        SaveMoney();
    }

    public static void ResetProfit()
    {
        ProfitCounter = 0;
    }

    public void SaveMoney()
    {
        TotalMoney += ProfitCounter;
        PlayerPrefs.SetInt("SaveMoney", TotalMoney);
    }

}
