using UnityEngine;
using System.Collections;

public class StartScreen : BaseBehavior
{
	void Start ()
	{

	}

	void Update ()
	{

	}

	public void StartGame()
	{
		Application.LoadLevel("level-01");
	}
}
