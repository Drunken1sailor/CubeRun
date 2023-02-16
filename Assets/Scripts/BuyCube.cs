using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyCube : MonoBehaviour
{
    [SerializeField] private GameObject _buyBtn;
    [SerializeField] private GameObject _selectBtn;

    private int _money, _price;
    public void Buy()
    {
        _money = PlayerPrefs.GetInt("SaveMoney");
        _price = PlayerPrefs.GetInt(GetComponent<SelectCube>().SelectedCubeName + "Price");

        if (_money >= _price) 
        {
            PlayerPrefs.SetString(GetComponent<SelectCube>().SelectedCubeName, "Open");
            PlayerPrefs.SetInt("SaveMoney", _money - _price); 
            Profit.TotalMoney = PlayerPrefs.GetInt("SaveMoney");

            _buyBtn.SetActive(false);
            _selectBtn.SetActive(true);
        } 
    }
}
