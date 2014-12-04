using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Hud : BaseBehavior
{
	private PlayerController _player;
	private GUIStyle _textStyle = new GUIStyle();

	private Text _text;
	
	public GameObject TextGameObject;
	public GameObject EndGameUi;
	public GameObject HighScoreGo;

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerController>();
		EndGameUi.SetActive(false);
		
		_text = TextGameObject.GetComponent<Text>();

        _textStyle.normal.textColor = Color.black;
        _textStyle.fontSize = 24;
    }

    void Update()
    {
        if (!_player)
		{
			EndGameUi.SetActive(true);

			var cameraPosition = Camera.main.WorldToScreenPoint(Camera.main.transform.position);
			
			if (PlayerPrefs.HasKey(Constants.PreviousHighScoreKey) && PlayerPrefs.HasKey(Constants.HighScoreKey))
			{
				var oldScore = PlayerPrefs.GetInt(Constants.PreviousHighScoreKey);
				var score = PlayerPrefs.GetInt(Constants.HighScoreKey);
				
				if (score > oldScore)
					HighScoreGo.SetActive(true);
			}

			return;
		}

		_text.text = _player.DistanceTraveled.ToString();
    }

	public void Pause()
	{
		Time.timeScale = Time.timeScale == 1 ? 0 : 1;
	}
	
	public void HomeScreen()
	{
		Application.LoadLevel("start");
	}
	
	public void PlayAgain()
	{
		Application.LoadLevel("level-01");
	}
}
