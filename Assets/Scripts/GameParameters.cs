using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameParameters : MonoBehaviour
{
	[SerializeField] private GameObject _gameOver;
	[SerializeField] private GameObject _mainMenu;
	[SerializeField] private GameObject _gameProcessInterface;
	[SerializeField] private GameObject _DITxt;
	public static int AccelerationTime = 300;
	public static float SpeedOfBarriers = 3.0f;
	public static bool Pause;
	public static GameObject MainMenu;
	public static GameObject GameProcessInterface;

	private int _acTime;
	private Text _DI;
	private bool _turnOnDI = false;

	private void Awake()
	{
		MainMenu = _mainMenu;
		GameProcessInterface = _gameProcessInterface;
		PauseGame();
	}

	void Start() {
		_acTime = AccelerationTime;

		_DI = _DITxt.GetComponent(typeof(Text)) as Text;
	}

	void FixedUpdate() {
		if (_acTime < 0) {
			if (SpeedOfBarriers < 7f)
			{
				SpeedOfBarriers *= 1.1f;
			}

			_acTime = AccelerationTime;
		}
		if(!Pause) _acTime -= 1;

		

		if (Player.IsDead )
		{
			GameOver();
			if (Input.GetKeyDown(KeyCode.Escape)) Invoke("RestartLevel", 1f);
		}
	}
    private void Update()
    {
		DevUI();
	}
    public void ResumeGame()
	{
		Pause = false;
		MainMenu.SetActive(false);
		GameProcessInterface.SetActive(true);
		Rigidbody _rigidbody = SpawnPlayer.CurrentPlayerPrefab.GetComponent(typeof(Rigidbody)) as Rigidbody;
		_rigidbody.isKinematic = false;
		CameraMove._movementAccess = true;

	}
	public void PauseGame()
	{
		Pause = true;
		_mainMenu.SetActive(true);
		_gameProcessInterface.SetActive(false);
	}
	public void RestartLevel()
	{
		SceneManager.LoadScene("GameProcess");
		Score.ResetScore();
		Profit.ResetProfit();
		_gameOver.SetActive(false);
		Player.IsDead = false;
		SpawnBarriers.ResetSpawnTime();

		SpeedOfBarriers = 3.0f;
		_acTime = AccelerationTime;
	}
	public void GameOver()
    {
		_gameOver.SetActive(true); 
	}
	private void DevUI()
    {
		_DITxt.SetActive(_turnOnDI);
		_DI.text = "Developer interface\nSpawn of barriers Time = " + SpawnBarriers.Time +
			"\n Spawn of bariers _time = " + SpawnBarriers._time +
			"\n Series Time = " + SpawnBarriers.SeriesTime +
			"\nSpeed = " + SpeedOfBarriers;
		if (Input.GetKeyDown(KeyCode.F1)) _turnOnDI = !_turnOnDI;
	}
    
}
