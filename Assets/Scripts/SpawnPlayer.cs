using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] private GameObject[] _playerPrefab;
    public static string CurrentPlayer;
    public static GameObject[] PlayerPrefab;
    public static int PreviewItemIndex;
    public static GameObject CurrentPlayerPrefab;

    private static Vector3 _spawnPoint = new Vector3(0f,0.5f,-40f);
    private Vector3 _movement = new Vector3(0f, 0f, -3f);


    private void Awake()
    {
        PlayerPrefab = _playerPrefab;
        if (!PlayerPrefs.HasKey("CurrentPlayer"))
        {
            PlayerPrefs.SetString("CurrentPlayer", "PlayerMagicka");
        }
        SpawnCurrentPlayer();
    }
    private void Start()
    {
    }

    private void FixedUpdate()
    {
        /*if (!Shop.IsActive)
        {
            SpawnCurrentPlayer();
        }*/
        if (!Player.IsDead && CurrentPlayerPrefab.transform.position.z < -20f)
            CurrentPlayerPrefab.transform.Translate(new Vector3(0f, 0f, 5f) * 6f * Time.fixedDeltaTime);
    }

    public static void SkinPreview(int _index)
    {
        if (CurrentPlayerPrefab != PlayerPrefab[_index]) Destroy(CurrentPlayerPrefab);
        CurrentPlayerPrefab = Instantiate(PlayerPrefab[_index], _spawnPoint, PlayerPrefab[_index].transform.rotation);
        PreviewItemIndex = _index;

    }

    public static void SpawnCurrentPlayer()
    {
        CurrentPlayer = PlayerPrefs.GetString("CurrentPlayer");

        foreach (GameObject prefab in PlayerPrefab)
        {
            if (prefab.name.Equals(CurrentPlayer))
            {
                CurrentPlayerPrefab = Instantiate(prefab, _spawnPoint, prefab.transform.rotation);
                
            }
        }
        //if (CurrentPlayerPrefab.name != CurrentPlayer) Destroy(CurrentPlayerPrefab);
    }
}
