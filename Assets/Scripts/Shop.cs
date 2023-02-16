using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject _shop;
    [SerializeField] private GameObject _shopCubes;
    [SerializeField] private GameObject _shopUI;
    [SerializeField] private GameObject _startButton;
    [SerializeField] private GameObject _selectCube;
    public static bool IsActive;

    private void Awake()
    {
        IsActive = false;
        
    }

    public void ShopActivation()
    {
        if (IsActive)
        {
            _selectCube.GetComponent<SelectCube>().Rotation = false;
           _selectCube.GetComponent<SelectCube>().SelectedCube.transform.localScale -= new Vector3(0.3f, 0.3f, 0.3f);
            _selectCube.GetComponent<SelectCube>().SelectedCube.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);

            _shop.SetActive(false);
            _startButton.SetActive(true);
            _shopCubes.transform.localPosition = new Vector3(0f, 0f, 0f);
            _shopUI.SetActive(false);
            IsActive = false; 
        }
        else
        {
            _shop.SetActive(true);
            _startButton.SetActive(false);
            _shopUI.SetActive(true);
            IsActive = true;
        }
        
    }
    
    public void StartGame()
    {
        if (IsActive)
        {
            _shopCubes.SetActive(false);
            _shopUI.SetActive(false);
            IsActive = false;
        }
    }

    /*private void SetActiveFalseForShop()
    {
        _shop.SetActive(false);
        _shopBackground.SetActive(false);
    }*/
}
