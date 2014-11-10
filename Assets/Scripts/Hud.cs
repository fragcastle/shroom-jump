using UnityEngine;
using System.Collections;

public class Hud : MonoBehaviour
{
	private float _distanceTraveled = 0;
	private Transform _player;

	public float DistanceScale = 100;

	void Start ()
	{
		_player = GameObject.Find ("Player").transform;
	}

	void Update ()
	{
		if (_player.position.y * DistanceScale > _distanceTraveled)
			_distanceTraveled = (int)(_player.position.y * DistanceScale);
	}

	void OnGUI ()
	{
		GUI.Label (new Rect (10, 10, 100, 20), _distanceTraveled.ToString ());
	}
}
