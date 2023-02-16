using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCube : MonoBehaviour
{
    [SerializeField] private GameObject _selectBtn, _buyBtn;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private Text _price;
    public string SelectedCubeName;
    public GameObject SelectedCube;
    public bool Rotation;

    private Vector3 _newScale = new Vector3(0.3f, 0.3f, 0.3f);

    private void Start()
    {
        if (!PlayerPrefs.HasKey("PlayerMagicka"))
        {
            PlayerPrefs.SetString("PlayerMagicka", "Open");
        }

        if (!PlayerPrefs.HasKey("PlayerMncrftPrice") || !PlayerPrefs.HasKey("PlayerRubikPrice"))
        {
            PlayerPrefs.SetInt("PlayerMncrftPrice", 500);
            PlayerPrefs.SetInt("PlayerRubikPrice", 800);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        SelectedCube = other.gameObject;
        SelectedCubeName = other.gameObject.name;
        Rotation = true;

        other.transform.localScale += _newScale;
        
        if (PlayerPrefs.GetString(SelectedCubeName) == "Open") {
            _selectBtn.SetActive(true);
            _buyBtn.SetActive(false);
        } else
        {
            _selectBtn.SetActive(false);
            _buyBtn.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Rotation = false;
        other.transform.localScale -= _newScale;
        SelectedCube.transform.rotation = new Quaternion(0f,0f,0f,0f); 
    }

    private void FixedUpdate()
    {
        if (PlayerPrefs.GetString(SelectedCubeName) != "Open")
        {
            _price.color = Color.yellow;
            _price.text = "$" + PlayerPrefs.GetInt(SelectedCubeName + "Price");
        }
        else
        {
            _price.color = Color.white;
            _price.text = "Bought!";
        }
        if (Rotation)
        {
            Quaternion _rotationY = Quaternion.AngleAxis(_speed, Vector3.up);
            SelectedCube.transform.rotation *= _rotationY;
        }
    }

    public void SelectPlayerCube()
    {
        PlayerPrefs.SetString("CurrentPlayer", SelectedCubeName);
        Destroy(SpawnPlayer.CurrentPlayerPrefab);
        SpawnPlayer.SpawnCurrentPlayer();
    }
}
