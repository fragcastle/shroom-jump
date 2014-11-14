using UnityEngine;
using System.Collections;

public class Hud : MonoBehaviour
{
	private float _distanceTraveled = 0;
	private Transform _player;
	private GUIStyle _textStyle = new GUIStyle();

	public float DistanceScale = 100;

	void Start ()
	{
		_player = GameObject.Find ("Player").transform;

		_textStyle.normal.textColor = Color.black;
		_textStyle.fontSize = 24;
	}

	void Update ()
	{
        if (!_player)
            return;

		if (_player.position.y * DistanceScale > _distanceTraveled)
			_distanceTraveled = (int)(_player.position.y * DistanceScale);
	}

	void OnGUI ()
	{
		GUI.Label(new Rect (10, 10, 100, 20), _distanceTraveled.ToString(), _textStyle);
	}
}
