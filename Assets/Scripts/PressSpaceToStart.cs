using UnityEngine;
using System.Collections;

public class PressSpaceToStart : BaseBehavior
{
	void Start ()
	{
		guiText.text = IsMobile() ? "Tap to play" : "Press space to play";
	}

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
		{
			Application.LoadLevel("level-01");
		}
	}
}
