using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Hud : BaseBehavior
{
	private PlayerController _player;
	private GUIStyle _textStyle = new GUIStyle();
	private GUIStyle _buttonStyle = new GUIStyle();

	private string _playAgainText = "";
	private string _newHighScoreText = "New High Score!";

	private Text _text;
	
	public GameObject TextGameObject;
	public GameObject RestartGameObject;

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerController>();
		
		_text = TextGameObject.GetComponent<Text>();

        _textStyle.normal.textColor = Color.black;
        _textStyle.fontSize = 24;

		_playAgainText = IsMobile() ? "Tap to play again" : "Press space to play again";
    }

    void Update()
    {
        if (!_player)
		{
			if (Input.GetKeyDown(KeyCode.Space)|| (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
			{
				Application.LoadLevel("level-01");
			}

			return;
		}

		_text.text = _player.DistanceTraveled.ToString();
    }

    void OnGUI()
	{
		_textStyle.alignment = TextAnchor.MiddleLeft;
		
		if (!_player)
		{
			var cameraPosition = Camera.main.WorldToScreenPoint(Camera.main.transform.position);
			
			_textStyle.alignment = TextAnchor.MiddleCenter;
			GUI.Label(new Rect(cameraPosition.x, cameraPosition.y, 20, 20), _playAgainText, _textStyle);
			
			if (PlayerPrefs.HasKey(Constants.PreviousHighScoreKey) && PlayerPrefs.HasKey(Constants.HighScoreKey))
			{
				var oldScore = PlayerPrefs.GetInt(Constants.PreviousHighScoreKey);
				var score = PlayerPrefs.GetInt(Constants.HighScoreKey);
				
				if (score > oldScore)
					GUI.Label(new Rect(cameraPosition.x, cameraPosition.y + 20, 20, 20), _newHighScoreText.ToString(), _textStyle);
			}
		}
    }

	public void Pause()
	{
		Debug.Log ("Pause");
		Time.timeScale = Time.timeScale == 1 ? 0 : 1;
	}
}
