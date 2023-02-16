using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
	[SerializeField] private Text _score;
	[SerializeField] private Text _highScore;
	public static Score InstanceScore;
	public static int ScoreCounter , HighScoreCounter;

    private void Awake()
    {
		InstanceScore = this;
		if (PlayerPrefs.HasKey("SaveScore"))
        {
			HighScoreCounter = PlayerPrefs.GetInt("SaveScore");
		}
		
    }

    void Update()
	{
		
		if (Input.GetKeyDown(KeyCode.Tab)) ResetHighScore();
		_score.text = "Score: " + ScoreCounter;
		_highScore.text = "HighScore: " + HighScoreCounter;
	}




	public void AddScore()
    {
		if (!GameParameters.Pause)
		{
			ScoreCounter++;
			HighScore();
		}
	}

	public void HighScore()
    {
		if (ScoreCounter > HighScoreCounter)
        {
			HighScoreCounter = ScoreCounter;

			PlayerPrefs.SetInt("SaveScore", HighScoreCounter);
        }
    }

	public static void ResetScore()
    {
		ScoreCounter = 0;
    }
	public void ResetHighScore()
	{
		PlayerPrefs.DeleteKey("SaveScore");
		HighScoreCounter = 0;
	}

	
}
