using UnityEngine;
using System.Collections;

public class Hud : MonoBehaviour
{
    private float _distanceTraveled = 0;
    private Transform _player;
    private GUIStyle _textStyle = new GUIStyle();

    public float DistanceScale = 100;

    void Start()
    {
        _player = GameObject.Find("Player").transform;

        _textStyle.normal.textColor = Color.black;
        _textStyle.fontSize = 24;
    }

    void Update()
    {
        if (!_player)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				Application.LoadLevel("level-01");
			}

			return;
		}

        if (_player.position.y * DistanceScale > _distanceTraveled)
            _distanceTraveled = (int)(_player.position.y * DistanceScale);
    }

    void OnGUI()
	{
		_textStyle.alignment = TextAnchor.MiddleLeft;
        GUI.Label(new Rect(10, 10, 100, 20), _distanceTraveled.ToString(), _textStyle);

		if (!_player)
		{
			var cameraPosition = Camera.main.WorldToScreenPoint(Camera.main.transform.position);
			
			_textStyle.alignment = TextAnchor.MiddleCenter;
			GUI.Label(new Rect(cameraPosition.x, cameraPosition.y, 100, 20), "Press space to play again", _textStyle);
		}
    }
}
