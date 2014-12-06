using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Hud : BaseBehavior
{
    private PlayerController _player;
    private GameObject _platforms;
	private GUIStyle _textStyle = new GUIStyle();

	private Text _text;
	
	public GameObject TextGameObject;
    public GameObject EndGameUi;
    public GameObject HighScoreGo;
    public GameObject PauseUi;

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerController>();
        _platforms = GameObject.Find("Platforms");
        
		EndGameUi.SetActive(false);
        HighScoreGo.SetActive(false);
        
		_text = TextGameObject.GetComponent<Text>();

        _textStyle.normal.textColor = Color.black;
        _textStyle.fontSize = 24;
        
        if (PlayerPrefs.HasKey(Constants.SoundEnabled))
        {
            var soundEnabled = PlayerPrefs.GetInt(Constants.SoundEnabled) == 1;
            
            _platforms.audio.volume = soundEnabled ? 1 : 0; 
            
            var gameObject = GameObject.Find("SoundToggle");
            var toggle = gameObject.GetComponent<Toggle>();
            toggle.isOn = soundEnabled;
        }
        
        PauseUi.SetActive(false);
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
        
        var paused = Time.timeScale == 0;
        
        PauseUi.SetActive(paused);
        EndGameUi.SetActive(paused);
	}
	
	public void HomeScreen()
	{
        Time.timeScale = 1;
        
		Application.LoadLevel("start");
	}
	
	public void PlayAgain()
    {
        Time.timeScale = 1;
        
		Application.LoadLevel("level-01");
	}
    
    public void ToggleSound(bool enabled)
    {
        _platforms.audio.volume = enabled ? 1 : 0;
        
        PlayerPrefs.SetInt(Constants.SoundEnabled, enabled ? 1 : 0);
    }
}
