using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScoreDisplay : MonoBehaviour
{
	void Start ()
	{
		var text = GetComponent<Text>();
		
		if (PlayerPrefs.HasKey(Constants.HighScoreKey))
		{
			var highScore = PlayerPrefs.GetInt (Constants.HighScoreKey);
			
			text.text = highScore.ToString();
		}
		else
		{
			text.enabled = false;
		}
	}
	
	void Update ()
	{

	}
}
